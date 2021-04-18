using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DirectionalLightCaster2D))]
public class DirectionalLightCalculation : Editor
{
    DirectionalLightCaster2D script;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();

        script = target as DirectionalLightCaster2D;
        script.Bake();

        serializedObject.ApplyModifiedProperties();
    }
}
