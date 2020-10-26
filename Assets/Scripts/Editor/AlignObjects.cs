using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridManager))]
public class AlignObjects : Editor
{
    GridManager script;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        script = target as GridManager;

        if(GUILayout.Button("Align Objects"))
        {
            script.AlignObjects();
        }
    }
}
