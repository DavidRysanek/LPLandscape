using UnityEditor;
using UnityEngine;
using DRE.MeshTools;


public class VertexSeparatorWizard : EditorWindow
{
    string result;


    [MenuItem("GameObject/DRE/Separate vertices")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(VertexSeparatorWizard));
    }


    void OnGUI()
    {
        GUILayout.Label("Separates all vertices in the meaning that triangles do not share any vertices.\n" +
            "Every triangle will have it's own (three) vertices.\n" +
            "It's handy for flat-shading.");
        GUILayout.Space(20);

        if (GUILayout.Button("Separate vertices on selected game object")) {
            SeparateVertices(false, false);
        }
        if (GUILayout.Button("Separate vertices on selected game object and save the mesh as an asset")) {
            SeparateVertices(false, true);
        }
        GUILayout.Space(10);
        if (GUILayout.Button("Clone game object and separate vertices on the clone")) {
            SeparateVertices(true, false);
        }
        if (GUILayout.Button("Clone game object, separate vertices on the clone and save it's mesh")) {
            SeparateVertices(true, true);
        }

        GUILayout.Space(20);
        GUILayout.Label(result);
    }


    void SeparateVertices(bool cloneGameObject, bool saveMesh)
    {
        result = null;

        GameObject go = SelectedGameObject();
        MeshFilter mf = GetMeshFilter(go);
        if (go != null && mf != null) {
            // Clone
            if (cloneGameObject) {
                go = Clone(go);
            }
            // Separate
            Mesh m = GetMeshFilter(go).sharedMesh;
            SeparateVertices(m);
            // Save
            if (saveMesh) {
                Save(m, go.name);
            }
            // Result
            if (result == null) {
                result = "Done.";
            }
        }

    }


    GameObject SelectedGameObject()
    {
        GameObject go = Selection.activeGameObject;
        if (go == null) {
            result = "No game object selected.";
            Debug.LogError(result);
        }
        return go;
    }


    // Returns mesh filter only if it contains a mesh
    MeshFilter GetMeshFilter(GameObject gameObject)
    {
        if (gameObject == null) {
            return null;
        }

        MeshFilter mf = gameObject.GetComponent<MeshFilter>();
        if (mf == null) {
            result = "No mesh filter on the selected object.";
            Debug.LogError(result);
            return null;
        }

        Mesh m = mf.sharedMesh;
        if (m == null) {
            result = "No mesh on the selected object.";
            Debug.LogError(result);
            return null;
        }

        return mf;
    }


    GameObject Clone(GameObject gameObject)
    {
        // Create duplicate of given game object
        GameObject go = Instantiate(gameObject);
        go.name = gameObject.name + " (separated vertices)";
        // Due to previous checks, we suppose that the game object contains a mesh
        MeshFilter mf = go.GetComponent<MeshFilter>();
        Mesh m = Instantiate(mf.sharedMesh);
        mf.sharedMesh = m;

        Selection.activeObject = go.transform;

        return go;
    }


    void SeparateVertices(Mesh mesh)
    {
        // Separate the vertices and recalculate remaining mesh properties (normals)
        VertexSeparator.SeparateVerticesAndRecalculateNormals(mesh);
    }


    void Save(Mesh mesh, string name)
    {
        // Save a copy to disk
        string path = EditorUtility.SaveFilePanelInProject("Save mesh", name, "asset", "Specify where to save the mesh.");
        if (path.Length > 0) {
            AssetDatabase.CreateAsset(mesh, path);
            Selection.activeObject = mesh;
        } else {
            result = "Mesh not saved because no path was selected.";
        }
    }
}