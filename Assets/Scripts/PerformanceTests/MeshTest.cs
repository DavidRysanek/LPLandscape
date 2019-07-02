using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTest : MonoBehaviour
{
	private string report = null;

	Mesh mesh;

	void Start()
	{
		mesh = GetComponent<MeshFilter>().mesh;
		if (mesh == null) {
			string error = "No mesh on the selected object";
			Debug.Log (error);
			return;
		}
	}

	// LateUpdate  is called once per frame after all Update are done
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.M)) {
			Test();
		}
	}

    // Writing array or list takes roughly the same time

    // DEBUG
    // Array: 600ms
    // List : 600ms

    // RELEASE
    // Array: 310ms
    // List : 310ms
	void Test()
	{
        const int iterations = 10000;
		var array = new Vector3[iterations];
		var list = new List<Vector3>(iterations);

        // Init arrays with default values
		for (var i = 0; i < iterations; ++i)
		{
			array[i] = new Vector3(1, 2, 3);
			list.Add(new Vector3(1, 2, 3));
		}

		var stopwatch = new System.Diagnostics.Stopwatch();

		mesh.Clear();
		stopwatch.Reset();
		stopwatch.Start();
		for (var i = 0; i < iterations; ++i)
		{
			mesh.vertices = array;
		}
		var arrayWriteTime = stopwatch.ElapsedMilliseconds;

		mesh.Clear();
		stopwatch.Reset();
		stopwatch.Start();
		for (var i = 0; i < iterations; ++i)
		{
			mesh.SetVertices(list);
		}
		var listWriteTime = stopwatch.ElapsedMilliseconds;

        report = "Mesh - " + iterations + " iterations \n"
			+ "Test,     Array,      List \n"
			+ "Write,   " + arrayWriteTime + " ms ,   " + listWriteTime + " ms";
	}



	void OnGUI()
	{
		if (report != null) {
			GUI.TextArea(new Rect(0, 100, Screen.width, 100), report);
		} else {
			GUI.TextArea(new Rect(0, 100, Screen.width, 100), "Press M to start Mesh test");
		}
	}
}