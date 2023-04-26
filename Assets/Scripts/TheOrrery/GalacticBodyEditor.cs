using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using EMMath;

[CustomEditor(typeof(GalacticBody))]
public class GalacticBodyEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GalacticBody body = (GalacticBody)target;
        body.yearsPerMinute = EditorGUILayout.FloatField("Years Per Minute", body.yearsPerMinute);
        body.size = EditorGUILayout.FloatField("Size", body.size);
        body.rotationAxis = new MyVector3(EditorGUILayout.Vector3Field("Rotation Axis", body.rotationAxis.UnityVector()));
        body.rotationScale = EditorGUILayout.FloatField("Rotation Scale", body.rotationScale);
        if (GUILayout.Button("Create Orbit"))
        {
            body.CreateOrbit(Random.Range(2f, 10f), new MyVector3(0f, 90f, 0f));
        }
    }
}
