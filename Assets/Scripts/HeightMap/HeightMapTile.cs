using DRE.Noise;
using UnityEngine;


public class HeightMapTile : MonoBehaviour
{
    private HeightMapPlane plane;
    private WaterPlane water;


    public void Init(INoise noise)
    {
        plane = GetComponentInChildren<HeightMapPlane>();
        Debug.Assert(plane != null, "HeightMapPlane not found");

        water = GetComponentInChildren<WaterPlane>();
        Debug.Assert(water != null, "WaterPlane not found");

        plane.Init(noise);
    }


    public void GenerateMesh(int segmentCount, float segmentSize)
    {
        plane.GenerateMesh(segmentCount, segmentSize);
        water.GenerateMesh(segmentCount, segmentSize);
    }


    public void SetWaterLevel(float waterLevel)
    {
        water.SetWaterLevel(waterLevel);
    }
}
