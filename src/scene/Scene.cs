using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RayTracer
{
    /// <summary>
    /// Class to represent a ray traced scene, including the objects,
    /// light sources, and associated rendering logic.
    /// </summary>
    public class Scene
    {
        private SceneOptions options;
        private ISet<SceneEntity> entities;
        private ISet<PointLight> lights;
        private int maxDepth = 3;
        private int stage = 2;
        private double albedo = 0.2;
        private int AmbientLightSample = 16;

        /// <summary>
        /// Construct a new scene with provided options.
        /// </summary>
        /// <param name="options">Options data</param>
        public Scene(SceneOptions options = new SceneOptions())
        {
            this.options = options;
            this.entities = new HashSet<SceneEntity>();
            this.lights = new HashSet<PointLight>();
        }

        /// <summary>
        /// Add an entity to the scene that should be rendered.
        /// </summary>
        /// <param name="entity">Entity object</param>
        public void AddEntity(SceneEntity entity)
        {
            this.entities.Add(entity);
        }

        /// <summary>
        /// Add a point light to the scene that should be computed.
        /// </summary>
        /// <param name="light">Light structure</param>
        public void AddPointLight(PointLight light)
        {
            this.lights.Add(light);
        }

        /// <summary>
        /// Render the scene to an output image. This is where the bulk
        /// of your ray tracing logic should go... though you may wish to
        /// break it down into multiple functions as it gets more complex!
        /// </summary>
        /// <param name="outputImage">Image to store render output</param>
        public void Render(Image outputImage)
        {
            // Begin writing your code here...
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int antiAliasing = options.AAMultiplier;
            double aspectRatio = outputImage.Width / outputImage.Height;
            double fov = 60*Math.PI/180;
            Vector3 origin = options.CameraPosition;
            // Traverse all the pixels in the image, cast the ray and get the color
            Parallel.For(0, outputImage.Width, x => {
                Parallel.For(0, outputImage.Height, y => {
                    Color outputColor = new Color(0.0f, 0.0f, 0.0f);
                    // Anti-aliasing: sends antiAliasing times as many rays per pixel
                    for (int i = 0; i < antiAliasing; i++) {
                        for (int j=0; j < antiAliasing; j++) {
                            // Transfer the pixels to world space
                            // The coordinate for each pixel in the screen space
                            double pixelX = x + (i + 0.5)/antiAliasing;
                            double pixelY = y + (j + 0.5)/antiAliasing;
                            double xPosition = (2*pixelX / outputImage.Width-1) * Math.Tan(fov/2) * aspectRatio;
                            double yPosition = (1 - 2*(pixelY / outputImage.Height)) * Math.Tan(fov/2);
                            double zPosition = 1.0f;
                            // set the primary ray for each pixels
                            Vector3 direct = (new Vector3(xPosition, yPosition, zPosition) - origin).Normalized();
                            Ray primaryRay = new Ray(origin, direct);
                            outputColor += castRay(primaryRay, 0);
                        }
                    }
                    outputColor = (outputColor / (antiAliasing*antiAliasing)).SolveOverflow();
                    outputImage.SetPixel(x, y, outputColor);
                });
            });
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }
        public Color castRay(Ray primaryRay, int depth) {
            if (depth > maxDepth) return new Color(0.0f, 0.0f, 0.0f);
            Color hitColor = new Color(0.0f, 0.0f, 0.0f);
            double nearestDistance = -1;
            SceneEntity hitEntity = null;
            RayHit hit = null;
            RayHit nearestHit = null;
            // Check the primary ray whether hit the object, if hit, then get the color of the hit object
            foreach (SceneEntity entity in this.entities) {
                hit = entity.Intersect(primaryRay);
                if (hit != null) {
                    // nearestDistance for check which object is nearest to the camera and just render this object
                    double distance = (hit.Position - primaryRay.Origin).LengthSq();
                    if (nearestDistance == -1 || distance < nearestDistance) {
                        nearestDistance = distance;
                        hitEntity = entity;
                        nearestHit = hit;
                    }
                }
            }
            if (hitEntity != null) {
                if(stage == 1) hitColor = hitEntity.Material.Color;
                if(stage == 2) hitColor = ColorFromDifferentMaterial(hitEntity, nearestHit, depth);
            }
            return hitColor;
        }

        /// <summary>
        /// get the color when ray hit on the object has different material
        /// </summary>
        /// <param name="entity">the entity that ray hit. It conclude the material information</param>
        /// <param name="hit">RayHit that conclude the information that the ray hit on the object</param>
        /// <param name="depth">record the reflection times</param>
        /// <returns>the color for this pixel</returns>
        public Color ColorFromDifferentMaterial(SceneEntity entity, RayHit hit, int depth) {
            Color outputColor = new Color(0.0f, 0.0f, 0.0f);
            Vector3 reflection, refraction;
            Ray reflectRay, refractRay;
            switch(entity.Material.Type) {
                case Material.MaterialType.Diffuse:
                    outputColor = ColorDiffuse(hit, entity, depth);
                    break;
                case Material.MaterialType.Reflective:
                    //For the reflective material, get the reflective light then recur the updateColor function
                    reflection = Reflect(hit.Incident, hit.Normal);
                    reflectRay = new Ray(hit.Position + reflection*1e-8, reflection);
                    outputColor =  castRay(reflectRay, depth+1);
                    break;
                case Material.MaterialType.Refractive:
                    // get the reflection ratio and refraction ratio by Fresnel equation
                    double reflectedRatio = Fresnel(hit.Incident, hit.Normal, entity.Material.RefractiveIndex);
                    double refractedRatio = 1- reflectedRatio;
                    //get the reflective light and ray
                    reflection = Reflect(hit.Incident, hit.Normal);
                    reflectRay = new Ray(hit.Position + reflection*1e-8, reflection);
                    //get the refractive light and ray
                    refraction = Refract(hit.Incident, hit.Normal, entity.Material.RefractiveIndex);
                    refractRay = new Ray(hit.Position + refraction*1e-8, refraction);
                    //get color of reflection light and color of refraction light
                    Color reflectedColor = castRay(reflectRay, depth+1) * reflectedRatio;
                    Color refractedColor = castRay(refractRay, depth+1) * refractedRatio;
                    outputColor = reflectedColor + refractedColor;
                    break;
            }
            return outputColor.SolveOverflow();
        }

        /// <summary>
        /// get the color of diffuse material if the ray hit on a diffuse object
        /// </summary>
        /// <param name="hit">RayHit that conclude the information that the ray hit on the object</param>
        /// <param name="entity">the entity that hit by the ray</param>
        /// <param name="depth">record the reflection times</param>
        /// <returns>the color of the diffuse object</returns>
        public Color ColorDiffuse(RayHit hit, SceneEntity entity, int depth) {
            Color hitColor = new Color(0.0f, 0.0f, 0.0f);
            Vector3 hitPoint = hit.Position;
            Vector3 hitNormal = hit.Normal;
            // [comment]
            // Simulate diffuse object
            // [/comment]
            Color directLighting = new Color(0.0f, 0.0f, 0.0f);
            Color indirectLighting = new Color(0.0f, 0.0f, 0.0f);

            // [comment]
            // Compute direct lighting
            // [/comment]
            foreach(PointLight light in this.lights) {
                bool notShawdow = CheckShadow(light, hit, entities);
                if (!notShawdow) {
                    double lightStrength = Math.Abs(hitNormal.Dot((light.Position-hitPoint).Normalized()));
                    directLighting += light.Color * entity.Material.Color * lightStrength;
                } 
            }
            // [comment]
            // Compute indirect lighting
            // [/comment]
            if (options.AmbientLightingEnabled) {
                Vector3 Nt, Nb;
                if (Math.Abs(hitNormal.X) > Math.Abs(hitNormal.Y)) 
                    Nt = new Vector3(hitNormal.Z, 0, -hitNormal.X) / Math.Sqrt(hitNormal.X * hitNormal.X + hitNormal.Z * hitNormal.Z); 
                else 
                    Nt = new Vector3(0, -hitNormal.Z, hitNormal.Y) / Math.Sqrt(hitNormal.Y * hitNormal.Y + hitNormal.Z * hitNormal.Z); 
                Nb = hitNormal.Cross(Nt);
                double pdf = 1 / (2 * Math.PI);
                Random rd = new Random();
                Parallel.For(0, AmbientLightSample, n=> {
                    double r1 = rd.NextDouble();
                    double r2 = rd.NextDouble();
                    Vector3 sample = uniformSampleHemisphere(r1, r2);
                    Vector3 sampleWorld = new Vector3( 
                        sample.X * Nb.X + sample.Y * hitNormal.X + sample.Z * Nt.X,
                        sample.X * Nb.Y + sample.Y * hitNormal.Y + sample.Z * Nt.Y,
                        sample.X * Nb.Z + sample.Y * hitNormal.Z + sample.Z * Nt.Z);
                    // don't forget to divide by PDF and multiply by cos(theta)
                    Ray newRay = new Ray(hitPoint + sampleWorld*1e-8, sampleWorld);
                    indirectLighting += castRay(newRay, depth + 1) *r1 / pdf;
                });
                // divide by N
                indirectLighting /= AmbientLightSample;
            }
            hitColor = directLighting + indirectLighting * albedo / Math.PI; 
            return hitColor;
        }

        public Vector3 uniformSampleHemisphere(double r1, double r2) {
            double sinTheta = Math.Sqrt(1 - r1 * r1); 
            double phi = 2 * Math.PI * r2; 
            double x = sinTheta * Math.Cos(phi); 
            double z = sinTheta * Math.Sin(phi); 
            return new Vector3(x, r1, z); 
        }

        /// <summary>
        /// get the light vector after the Reflection
        /// </summary>
        /// <param name="inputLight">inputlight vector conclude the angle of the light</param>
        /// <param name="normal">the normal of the hit position</param>
        /// <returns>the light vector after the reflection</returns>
        public Vector3 Reflect(Vector3 inputLight, Vector3 normal) 
        {
            return (inputLight - 2*inputLight.Dot(normal) * normal).Normalized();
        }

        /// <summary>
        /// Check whether the pixels can be illuminated by light sources
        /// </summary>
        /// <param name="light">light sources that conclude the light position</param>
        /// <param name="hit">RayHit that conclude the information that the ray hit on the object</param>
        /// <param name="entities">the set that concludes all the entities in the scene</param>
        /// <returns>if the pixels can not be illuminated by light sources, return true</returns>
        public bool CheckShadow(PointLight light, RayHit hit, ISet<SceneEntity> entities) 
        {
            // the ray to check the shadow
            Vector3 lightDirect = (light.Position-hit.Position).Normalized();
            double lengthToLight = (light.Position - hit.Position).LengthSq();
            Ray checkShadowRay = new Ray(hit.Position + lightDirect*1e-8, lightDirect);
            foreach (SceneEntity entity in entities) {
                RayHit shawdowHit = entity.Intersect(checkShadowRay);
                if (shawdowHit != null) {
                    // Check the object is on the back of the light or on the front of the light
                    double lengthToBlock = (shawdowHit.Position - hit.Position).LengthSq();
                    if (lengthToBlock<lengthToLight) return true;
                }
            }
            return false;
        }

        /// <summary>
        /// get the light vector after the Refraction
        /// </summary>
        /// <param name="inputLight">inputlight vector conclude the angle of the light</param>
        /// <param name="normal">the normal of the hit position</param>
        /// <param name="refractiveIndex">effect the angle of refraction</param>
        /// <returns>the light vector after the refraction</returns>
        public Vector3 Refract(Vector3 inputLight, Vector3 normal, double refractiveIndex) 
        { 
            double cosI = Math.Clamp(inputLight.Dot(normal), -1, 1); 
            double etaI = 1;
            double etaT = refractiveIndex;
            Vector3 n = normal; 
            if (cosI < 0) { 
                cosI = -cosI; 
            } 
            else { 
                double swap = etaT;
                etaT = etaI; 
                etaI = swap;
                n= -normal; 
            } 
            double eta = etaI / etaT; 
            double k = 1 - eta * eta * (1 - cosI * cosI); 
            return k < 0 ? new Vector3(0.0f, 0.0f, 0.0f) : (eta * inputLight + (eta * cosI - Math.Sqrt(k)) * n).Normalized(); 
        }

        /// <summary>
        /// get the Reflected Ratio when the light hit on the refractive material
        /// Refracted Ratio = (1 - Reflected Ratio)
        /// </summary>
        /// <param name="inputLight">inputlight vector conclude the angle of the light</param>
        /// <param name="normal">the normal of the hit position</param>
        /// <param name="refractiveIndex">effect the angle of refraction</param>
        /// <returns>the reflectedRatio of the light</returns>
        public double Fresnel(Vector3 inputLight, Vector3 normal, double refractiveIndex) 
        {       
            double cosI = Math.Clamp(inputLight.Dot(normal), -1, 1); 
            double reflectedRatio;
            double etaI = 1, etaT = refractiveIndex; 
            if (cosI > 0) {
                double swap = etaI;
                etaI = etaT;
                etaT = swap;
            } 
            // Compute sinI using Snell's law
            double max = 0.0f > 1 - cosI * cosI ? 0.0f:1 - cosI * cosI;
            double sinT = etaI / etaT * Math.Sqrt(max); 
            // Total internal reflection
            if (sinT >= 1) { 
                reflectedRatio = 1; 
            } 
            else { 
                max = 0.0f > 1 - sinT * sinT ? 0.0f:1 - sinT * sinT;
                double cost = Math.Sqrt(max); 
                cosI = Math.Abs(cosI); 
                double Rs = ((etaT * cosI) - (etaI * cost)) / ((etaT * cosI) + (etaI * cost)); 
                double Rp = ((etaI * cosI) - (etaT * cost)) / ((etaI * cosI) + (etaT * cost)); 
                reflectedRatio = (Rs * Rs + Rp * Rp) / 2; 
            } 
            return reflectedRatio;
        }
    }        
}
