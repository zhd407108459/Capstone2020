using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PointLightCaster2D))]
public class PointLightCalculation : Editor
{
    PointLightCaster2D script;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();
        
        script = target as PointLightCaster2D;
        script.Bake();

        serializedObject.ApplyModifiedProperties();
    }

    
}
