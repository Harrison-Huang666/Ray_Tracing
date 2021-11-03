using System;

namespace RayTracer
{
    /// <summary>
    /// Class to represent a triangle in a scene represented by three vertices.
    /// </summary>
    public class Triangle : SceneEntity
    {
        private Vector3 v0, v1, v2;
        private Material material;

        /// <summary>
        /// Construct a triangle object given three vertices.
        /// </summary>
        /// <param name="v0">First vertex position</param>
        /// <param name="v1">Second vertex position</param>
        /// <param name="v2">Third vertex position</param>
        /// <param name="material">Material assigned to the triangle</param>
        public Triangle(Vector3 v0, Vector3 v1, Vector3 v2, Material material)
        {
            this.v0 = v0;
            this.v1 = v1;
            this.v2 = v2;
            this.material = material;
        }

        /// <summary>
        /// Determine if a ray intersects with the triangle, and if so, return hit data.
        /// </summary>
        /// <param name="ray">Ray to check</param>
        /// <returns>Hit data (or null if no intersection)</returns>
        public RayHit Intersect(Ray ray)
        {
            Vector3 v0v1 = v1-v0;
            Vector3 v0v2 = v2-v0;
            Vector3 pVec = ray.Direction.Cross(v0v2);
            double det = v0v1.Dot(pVec);
            if (Math.Abs(det) < 1e-8) return null; 

            double invDet = 1/det;
            Vector3 tVec = ray.Origin - v0;

            double u = tVec.Dot(pVec)*invDet;
            if (u < 0 || u > 1) return null;
            Vector3 qVec = tVec.Cross(v0v1); 

            double v = ray.Direction.Dot(qVec) * invDet; 
            if (v < 0 || u + v > 1) return null; 
 
            double t = v0v2.Dot(qVec) * invDet;
            if (t<=0) return null;
            Vector3 normal = (v1-v0).Cross(v2-v0).Normalized();
            Vector3 hitPosition = ray.Origin + ray.Direction*t;
            RayHit hit = new RayHit(hitPosition, normal, ray.Direction, material);
            return hit;
        }

        /// <summary>
        /// The material of the triangle.
        /// </summary>
        public Material Material { get { return this.material; } }
    }

}
