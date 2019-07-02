using UnityEditor;
using UnityEngine;
using DRE.MeshTools;

public class PlaneWizard : ScriptableWizard
{
    [MenuItem("Assets/Create/DRE/Plane")]
    private static void CreateWizard ()
    {
        ScriptableWizard.DisplayWizard<PlaneWizard>("Create Plane");
    }

    [Range(1, 100)]
    public int segments = 10;
    [Range(1, 100)]
    public float segmentSize = 1f;
    [Range(0, 1)]
    public float anchorPoint = .5f;

    private void OnWizardCreate ()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Plane", "Plane", "asset", "Specify where to save the mesh.");
        if (path.Length > 0) {
            Mesh mesh = PlaneCreator.Create(segments, segmentSize, anchorPoint);
            AssetDatabase.CreateAsset(mesh, path);
            Selection.activeObject = mesh;
        }
    }
}