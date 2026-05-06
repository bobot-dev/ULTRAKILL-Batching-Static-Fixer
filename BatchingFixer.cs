using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

//[UnityEditor.InitializeOnLoad]
public class BatchingFixer : Editor
{
    static BatchingFixer()
    {
        //EditorSceneManager.sceneSaving += OnSceneSaving;
    }

    static void OnSceneSaving(UnityEngine.SceneManagement.Scene scene, string path)
    {
        var things = FindObjectsOfType<PreservedOriginalMesh>(true);

        foreach (var preservedOriginalMesh in things)
        {
            if (preservedOriginalMesh.TryGetComponent(out MeshFilter meshFilter))
                preservedOriginalMesh.mesh = meshFilter.sharedMesh;
        }
    }
}
