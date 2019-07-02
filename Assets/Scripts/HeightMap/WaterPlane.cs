using DRE.MeshTools;
using UnityEngine;


public class WaterPlane : MonoBehaviour
{
    private Mesh mesh;


    public void GenerateMesh(int segmentCount, float segmentSize)
    {
        mesh = GetComponent<MeshFilter>().mesh;
        if (mesh == null) {
            Debug.LogError("No mesh on the selected object");
            return;
        }

        PlaneCreator.CreateVertices(mesh, segmentCount, segmentSize, .5f);
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }


    public void SetWaterLevel(float waterLevel)
    {
        var position = transform.position;
        position.y = waterLevel;
        transform.position = position;
    }
}
