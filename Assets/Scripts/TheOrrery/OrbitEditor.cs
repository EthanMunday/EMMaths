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
        MyVector3 newAxis = new MyVector3(EditorGUILayout.Vector3Field("Rotation Axis", thisOrbit.axis.UnityVector()));
        if(newAxis.x != 0f || newAxis.y != 0f || newAxis.z != 0f)
        {
            thisOrbit.axis = newAxis;
        }

        if (GUILayout.Button("Create Planet"))
        {
            thisOrbit.CreateBody(20f);
        }
    }
}
