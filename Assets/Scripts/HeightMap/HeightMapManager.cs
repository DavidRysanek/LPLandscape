using UnityEngine;
using System;
using System.Collections.Generic;
using DRE.Noise;


public class HeightMapManager : MonoBehaviour
{
    private INoise noise;
    private INoise noiseGenerator;

    [SerializeField]
    GameObject heightMapTilePrefab;
    [SerializeField]
    private int tilesCountX = 2;
    [SerializeField]
    private int tilesCountZ = 2;
    [SerializeField]
    private int tileSize = 100;
    [SerializeField]
    private float waterLevel = -2;

    private List<GameObject> tileGOs = new List<GameObject>();


    #region Initialisation

    void Start()
    {
        // Random noise seed based on system clock
        ulong seed = (ulong)Environment.TickCount;
        InitNoise(seed);
        InstantiateTiles(noiseGenerator);
        GenerateTileMesh(tileSize);
        SetWaterLevel(waterLevel);
    }


    private void InstantiateTiles(INoise noiseGenerator)
    {
        int offsetX = (tilesCountX - 1) * tileSize / 2;
        int offsetZ = (tilesCountZ - 1) * tileSize / 2;

        for (int x = 0; x < tilesCountX; x++)
        {
            for (int z = 0; z < tilesCountZ; z++)
            {
                var tileGO = Instantiate(heightMapTilePrefab);
                tileGO.transform.parent = transform;
                tileGO.transform.position = new Vector3(tileSize * x - offsetX, 0, tileSize * z - offsetZ);
                tileGOs.Add(tileGO);

                var tile = tileGO.GetComponent<HeightMapTile>();
                tile.Init(noiseGenerator);
            }
    }

        return;
    }


    private void GenerateTileMesh(int tileSize)
    {
        for (int i = 0; i < tileGOs.Count; i++)
        {
            tileGOs[i].GetComponent<HeightMapTile>().GenerateMesh(tileSize, 1);
        }
    }


    private void SetWaterLevel(float waterLevel)
    {
        for (int i = 0; i < tileGOs.Count; i++)
        {
            tileGOs[i].GetComponent<HeightMapTile>().SetWaterLevel(waterLevel);
        }
    }

    #endregion


    #region Noise

    private void InitNoise(ulong seed)
    {
        noise = new SimplexNoise(seed);
        noiseGenerator = GetLinearNoiseGenerator(noise);
    }


    // Variant: standard
    private INoise GetLinearNoiseGenerator(INoise noise)
    {
        return new LinearSimplexNoiseGenerator(noise);
    }


    // Variant: exponential noise
    private INoise GetExponentialNoiseGenerator(INoise noise)
    {
        return new ExponentialSimplexNoiseGenerator(noise);
    }


    // Variant: Checker board
    private INoise GetCheckerBoardNoiseGenerator(INoise noise)
    {
        INoise n1 = new CheckerBoardNoise();
        INoise n2 = new ExponentialSimplexNoiseGenerator(noise);
        return new NoiseAdd(n1, n2, 0.2);
    }

    #endregion
}
