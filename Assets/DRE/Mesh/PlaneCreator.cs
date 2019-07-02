using UnityEngine;
using System.Collections.Generic;
using DRE.Mathematics;

namespace DRE.MeshTools
{
    public static class PlaneCreator
    {
        public static Mesh Create(int segments, float segmentSize, float anchor)
        {
            Mesh mesh = new Mesh();
            mesh.name = "Plane";
            CreateVertices(mesh, segments, segments, segmentSize, segmentSize, anchor, anchor);
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();
            return mesh;
        }

    	public static void CreateVertices(Mesh mesh)
    	{
            CreateVertices(mesh, 50, 50, 1, 1, .5f, .5f);
    	}


        public static void CreateVertices(Mesh mesh, int segments, float segmentSize)
        {
            CreateVertices(mesh, segments, segments, segmentSize, segmentSize, .5f, .5f);
        }


        public static void CreateVertices(Mesh mesh, int segments, float segmentSize, float anchor)
        {
            CreateVertices(mesh, segments, segments, segmentSize, segmentSize, anchor, anchor);
        }


        /// Generates mesh (vertices, triangles and UVs) for plane in XZ space.
        /// You need to RecalculateBounds() and RecalculateNormals()
        public static void CreateVertices(Mesh mesh, int xSegments, int zSegments, float xSegmentSize, float zSegmentSize, float xAnchor, float zAnchor)
        {
            mesh.Clear();

            int xVertices = xSegments + 1;
            int zVertices = zSegments + 1;
            int trianglesCount = xSegments * zSegments * 6;
            int verticesCount = xVertices * zVertices;

            float xOffset = -(xSegments * xSegmentSize * xAnchor);
            float zOffset = -(zSegments * zSegmentSize * zAnchor);

            Vector3[] vertices = new Vector3[verticesCount];
            Vector2[] uvs = new Vector2[verticesCount];
            int[] triangles = new int[trianglesCount]; // List of indexes of vertices (0,1,2...)

            // Vertices + UVs
            int i = 0;
            for (float z = 0.0f; z < zVertices; z++)
            {
                for (float x = 0.0f; x < xVertices; x++)
                {
                    vertices[i] = new Vector3(x * xSegmentSize + xOffset, 0, z * zSegmentSize + zOffset);
                    uvs[i] = new Vector2(x / xSegments, z / zSegments);
                    i++;
                }
            }

            // Triangles
            i = 0;
            for (int z = 0; z < zSegments; z++)
            {
                for (int x = 0; x < xSegments; x++)
                {
                    triangles[i]   = (z     * xVertices) + x;
                    triangles[i+1] = ((z+1) * xVertices) + x;
                    triangles[i+2] = (z     * xVertices) + x + 1;

                    triangles[i+3] = ((z+1) * xVertices) + x;
                    triangles[i+4] = ((z+1) * xVertices) + x + 1;
                    triangles[i+5] = (z     * xVertices) + x + 1;
                    i += 6;
                }
            }

            mesh.vertices = vertices;
            mesh.uv = uvs;
            mesh.triangles = triangles;
        }
    }
}