using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DRE.MeshTools
{
    public static class VertexSeparator
    {
        /// Separates vertices in the meaning that no vertex is shared and recalculate remaining properties (normals).
        public static void SeparateVerticesAndRecalculateNormals(Mesh mesh)
        {
            SeparateVertices(mesh);
            mesh.RecalculateNormals();
        }


        /// Separates vertices in the meaning that no vertex is shared.
        /// You need to RecalculateNormals()
    	public static void SeparateVertices(Mesh mesh)
    	{
    		// Array of vertex indices {0, 1, 2...}
    		int[] triangles = mesh.triangles;

            // Vertices
    		Vector3[] oldVertices = mesh.vertices; // Array length < triangles.length
    		int oldVerticesCount = oldVertices.Length;
    		int verticesCount = triangles.Length;
            Vector3[] vertices = new Vector3[verticesCount]; // Array length = triangles.length

            // Colors
            Color[] oldColors = mesh.colors;
            Color[] colors = null;
            if (oldColors != null && oldColors.Length == oldVerticesCount) {
                colors = new Color[verticesCount]; // We can copy colors
            }

            // UVs
            Vector2[] oldUVs = mesh.uv;
            Vector2[] UVs = null;
            if (oldUVs != null && oldUVs.Length == oldVerticesCount) {
                UVs = new Vector2[verticesCount]; // We can copy UVs
            }

            // Normals
            // Copying normals doesn't make sense, because they have "interpolated/smoothed" values
            // and the flat-shaded effect won't be achieved

            // Process data
    		for (int i = 0; i < verticesCount; i++)
    		{
                int oldIndex = triangles[i];

    			vertices[i] = oldVertices[oldIndex];
                triangles[i] = i;

    			if (colors != null) {
    				colors[i] = oldColors[oldIndex];
    			}
                if (UVs != null) {
                    UVs[i] = oldUVs[oldIndex];
                }
    		}

            // Set new data
    		mesh.vertices = vertices;
    		mesh.triangles = triangles;
    		mesh.colors = colors;
            mesh.uv = UVs;
    	}
    }
}