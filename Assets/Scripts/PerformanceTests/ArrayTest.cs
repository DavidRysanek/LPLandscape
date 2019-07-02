using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DRE.Mathematics;

public class ArrayTest : MonoBehaviour
{
	private string report = null;

    
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.A)) {
			ReadWriteTest();
		}
	}

	// int[] is about 2X faster than List<int>
	void IntAddTest()
	{
        const int iterations = 1000000;
		var array = new int[iterations];
		var list = new List<int>(iterations);

		var stopwatch = new System.Diagnostics.Stopwatch();

		stopwatch.Reset();
		stopwatch.Start();
		for (var i = 0; i < iterations; ++i)
		{
			array[i] = i;
		}
		var arrayWriteTime = stopwatch.ElapsedMilliseconds;

		stopwatch.Reset();
		stopwatch.Start();
		for (var i = 0; i < iterations; ++i)
		{
			list.Add(i);
		}
		var listWriteTime = stopwatch.ElapsedMilliseconds;

        report = "Array: set/add int - " + iterations + " iterations \n"
			+ "Test,     Array,      List \n"
			+ "Write,   " + arrayWriteTime + " ms ,   " + listWriteTime;
	}

	// Vector3[] is about 2X faster than List<Vector3>
	void VectorAddTest()
	{
        const int iterations = 1000000;
		var array = new Vector3[iterations];
		var list = new List<Vector3>(iterations);

		var stopwatch = new System.Diagnostics.Stopwatch();

		stopwatch.Reset();
		stopwatch.Start();
		for (var i = 0; i < iterations; ++i)
		{
			array[i] = new Vector3(1, 2, 3);
		}
		var arrayWriteTime = stopwatch.ElapsedMilliseconds;

		stopwatch.Reset();
		stopwatch.Start();
		for (var i = 0; i < iterations; ++i)
		{
			list.Add(new Vector3(1, 2, 3));
		}
		var listWriteTime = stopwatch.ElapsedMilliseconds;

        report = "Array: set/add Vectore3 - " + iterations + " iterations \n"
            + "Test,     Array,      List \n"
			+ "Write,   " + arrayWriteTime + " ms ,   " + listWriteTime;
	}


    // DEBUG build:
	// array: read  260ms, write 250ms
	// list : read  570ms, write 970ms

    // RELEASE build:
    // array: read  80ms, write  18ms
    // list : read 100ms, write 130ms
	void ReadWriteTest()
	{
        const int iterations = 3000;
        const int size = 10000;

		var stopwatch = new System.Diagnostics.Stopwatch();
		int sum;
		var array = new int[size];
		var list = new List<int>(size);
		for (var i = 0; i < size; ++i)
		{
			array[i] = i;
			list.Add(i);
		}

		stopwatch.Reset();
		stopwatch.Start();
		for (var it = 0; it < iterations; ++it)
		{
			sum = 0;
			for (var i = 0; i < size; ++i)
			{
				sum += array[i];
			}
		}
		var arrayReadTime = stopwatch.ElapsedMilliseconds;

		stopwatch.Reset();
		stopwatch.Start();
		for (var it = 0; it < iterations; ++it)
		{
			for (var i = 0; i < size; ++i)
			{
				array[i] = i;
			}
		}
		var arrayWriteTime = stopwatch.ElapsedMilliseconds;

		stopwatch.Reset();
		stopwatch.Start();
		for (var it = 0; it < iterations; ++it)
		{
			sum = 0;
			for (var i = 0; i < size; ++i)
			{
				sum += list[i];
			}
		}
		var listReadTime = stopwatch.ElapsedMilliseconds;

		stopwatch.Reset();
		stopwatch.Start();
		for (var it = 0; it < iterations; ++it)
		{
			for (var i = 0; i < size; ++i)
			{
				list[i] = i;
			}
		}
		var listWriteTime = stopwatch.ElapsedMilliseconds;

        report = "Read/Write int - " + size + " iterations \n"
			+ "Test,     Array,      List\n"
			+ "Read,   " + arrayReadTime + " ms ,   " + listReadTime + "\n"
			+ "Write,   " + arrayWriteTime + " ms ,   " + listWriteTime;
		
		//Debug.Log(report);
	}


	void OnGUI()
	{
		if (report != null) {
			GUI.TextArea(new Rect(0, 0, Screen.width, 100), report);
		} else {
			GUI.TextArea(new Rect(0, 0, Screen.width, 100), "Press A to start the Array test");
		}
	}


    Vector3I voxelCount = new Vector3I(4,3,2);
    //int voxelListLength = 4*3*2;

    private void testVoxel()
    {
        testVoxel(new Vector3I(3,2,1));
        testVoxel(new Vector3I(0,1,1));

        testVoxel(new Vector3I(1,0,0));
        testVoxel(new Vector3I(2,0,0));

        testVoxel(new Vector3I(0,0,0));
        testVoxel(new Vector3I(0,0,1));
        testVoxel(new Vector3I(0,1,0));
    }

    private void testVoxel(Vector3I p)
    {
        int i = to1D(p);
        var v = to3D(i);
        Debug.Log(p + " = " + i + " = " + v);
    }

    private int to1D(Vector3I position)
    {
        int i = (position.z * voxelCount.x * voxelCount.y) + (position.y * voxelCount.x) + position.x;
        return i;
    }


    public Vector3I to3D( int index ) {
        int z = index / (voxelCount.x * voxelCount.y);
        index -= (z * voxelCount.x * voxelCount.y);
        int y = index / voxelCount.x;
        int x = index % voxelCount.x;
        return new Vector3I(x,y,z);
    }
}