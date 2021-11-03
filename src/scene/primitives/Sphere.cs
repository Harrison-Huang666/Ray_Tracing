using System;

namespace RayTracer
{
    /// <summary>
    /// Class to represent an (infinite) plane in a scene.
    /// </summary>
    public class Sphere : SceneEntity
    {
        private Vector3 center;
        private double radius;
        private Material material;

        /// <summary>
        /// Construct a sphere given its center point and a radius.
        /// </summary>
        /// <param name="center">Center of the sphere</param>
        /// <param name="radius">Radius of the sphere</param>
        /// <param name="material">Material assigned to the sphere</param>
        public Sphere(Vector3 center, double radius, Material material)
        {
            this.center = center;
            this.radius = radius;
            this.material = material;
        }

        /// <summary>
        /// Determine if a ray intersects with the sphere, and if so, return hit data.
        /// </summary>
        /// <param name="ray">Ray to check</param>
        /// <returns>Hit data (or null if no intersection)</returns>
        public RayHit Intersect(Ray ray)
        {
            double t0, t1;
            RayHit rayHit;
            Vector3 hitPosition, hitNormal;

            //analytic
            Vector3 L = ray.Origin - center;
            double a = ray.Direction.Dot(ray.Direction);
            double b = 2 * ray.Direction.Dot(L);
            double c = L.Dot(L) - radius*radius;
            double discriminant = b * b - 4 * a * c; 
            if (discriminant < 0) return null; 
            if (discriminant == 0) {
                t0 = -b / (2*a);
                t1 = -b / (2*a); 
            } else { 
                double q = (b > 0) ?  -0.5 * (b + Math.Sqrt(discriminant)) : -0.5 * (b - Math.Sqrt(discriminant)); 
                t0 = q/a;
                t1 = c/q;
            } 
            if (t0 > t1) {
                t0 = t0 + t1;
                t1 = t0 - t1; 
                t0 = t0 - t1;
            }; 
            
            if (t0 <= 0) { 
                t0 = t1; // if t0 is negative, let's use t1 instead 
                if (t0 <= 0) return null; // both t0 and t1 are negative 
            } 
            hitPosition = ray.Origin + ray.Direction * t0;
            hitNormal = (hitPosition - center).Normalized();
            rayHit= new RayHit(hitPosition, hitNormal, ray.Direction, material);
            return rayHit;
        }

        /// <summary>
        /// The material of the sphere.
        /// </summary>
        public Material Material { get { return this.material; } }
    }

}
