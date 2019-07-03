using UnityEngine;
using DRE.Noise;
using DRE.MeshTools;


public class HeightMapPlane : MonoBehaviour
{
	private Mesh mesh;
	private INoise noise;
    

    public void Init(INoise noise)
    {
        this.noise = noise;
    }


    public void GenerateMesh(int segmentCount, float segmentSize)
    {
        mesh = GetComponent<MeshFilter>().mesh;
        Debug.Assert(mesh != null, "No mesh on the selected object");

        PlaneCreator.CreateVertices(mesh, segmentCount, segmentSize, .5f);
		ResolveNoiseHeigth(mesh);
		VertexSeparator.SeparateVertices(mesh);
		ColoriseVertices(mesh);
		ScaleVertices(mesh, new Vector3(1,8,1));

		mesh.RecalculateBounds();
		mesh.RecalculateNormals();
	}
		

	private void ResolveNoiseHeigth(Mesh mesh)
	{
		Vector3 worldPosition = transform.position;
		Vector3[] vertices = mesh.vertices;
		int vertexCount = vertices.Length;

		for (int i = 0; i < vertexCount; i++)
		{
			Vector3 localPosition = vertices[i];
			Vector3 noisePosition = WorldToNoise(worldPosition + localPosition);
			// Get height
			double h = noise.GetValue(noisePosition.x, noisePosition.z);
			localPosition.y = (float)h;
			vertices[i] = localPosition;
		}

		mesh.vertices = vertices;
	}

    private Vector3 WorldToNoise(Vector3 point)
	{
		return point * 0.05f;
	}


    private void ScaleVertices(Mesh mesh, Vector3 scale)
	{
		Vector3[] vertices = mesh.vertices;
		int vertexCount = vertices.Length;

		for (int i = 0; i < vertexCount; i++)
		{
			Vector3 v = vertices[i];
			v.Scale(scale);
			vertices[i] = v;
		}

		mesh.vertices = vertices;
	}

    private void ColoriseVertices(Mesh mesh)
	{
		Vector3[] vertices = mesh.vertices;
		int vertexCount = vertices.Length;
		Color[] colors = new Color[vertexCount];

		if (vertices.Length != colors.Length) {
			Debug.LogError("Tried to colorise separated vertices but number of vertices != number of colours");
			return;
		}

		if (vertexCount % 3 != 0) {
			Debug.LogError("Tried to colorise separated vertices but the vertices are not separated");
            return;
        }

		for (int i = 0; i < vertexCount; i++)
		{
			int triangleVertex = i % 3;
			// If last vertex of a triangle is set, resolve color for whole triangle
			if (triangleVertex == 2) {
//				float y = (vertices[i].y + vertices[i-1].y + vertices[i-2].y) / 3.0f; // Average height
//				float y = Mathf.Min( Mathf.Min(vertices[i-2].y, vertices[i-1].y), vertices[i].y ); // Min height
//				float y = Mathf.Max( Mathf.Max(vertices[i-2].y, vertices[i-1].y), vertices[i].y ); // Max height
//				Color color = ColorAtHeight(y);
				Color color = ColorAtHeight(vertices[i].y);
				colors[i] = color;
				colors[i-1] = color;
				colors[i-2] = color;
			}
		}

		mesh.colors = colors;
	}


    // Normalised height <-1, 1>
    private Color ColorAtHeight(float y) 
	{
		Color color;
		if (y > 0.3) {
			color = new Color(1,1,1);
		} else if (y > 0.1) {
			color = new Color(.3f, .3f, .3f);
		} else if (y > -0.2) {
			color = new Color(.7f, .4f, 0);
		}  else {
			color = new Color(0, .5f, 0);
		}
		return color;
	}

}
