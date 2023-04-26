using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using EMMath;

[CustomEditor(typeof(Orbit))]
public class OrbitEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Orbit thisOrbit = (Orbit)target;
        thisOrbit.radius = EditorGUILayout.FloatField("Radius", thisOrbit.radius);
        thisOrbit.axis = new MyVector3(EditorGUILayout.Vector3Field("Rotation Axis", thisOrbit.axis.UnityVector()));
        if (GUILayout.Button("Create Planet"))
        {
            thisOrbit.CreateBody(Random.Range(5f, 20f));
        }
    }
}
