using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using EMMath;

[CustomEditor(typeof(MyTransform))]
public class TransformEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MyTransform transform = (MyTransform)target;
        EditorGUILayout.LabelField("Position", transform.position.UnityVector().ToString());
        EditorGUILayout.LabelField("Angle", transform.rotation.angle.UnityVector().ToString());
        EditorGUILayout.LabelField("Euler", transform.rotation.euler.UnityVector().ToString());
        EditorGUILayout.LabelField("Matrix[0]", transform.rotation.matrix.GetColumn(1).UnityVector().ToString());
        EditorGUILayout.LabelField("Matrix[1]", transform.rotation.matrix.GetColumn(2).UnityVector().ToString());
        EditorGUILayout.LabelField("Matrix[2]", transform.rotation.matrix.GetColumn(3).UnityVector().ToString());
        EditorGUILayout.LabelField("Matrix[3]", transform.rotation.matrix.GetColumn(4).UnityVector().ToString());
        EditorGUILayout.LabelField("Quaternion Scale", transform.rotation.quaternion.w.ToString());
        EditorGUILayout.LabelField("Quaternion Axis", transform.rotation.quaternion.GetAxis().UnityVector().ToString());
        EditorGUILayout.LabelField("Scale", transform.scale.UnityVector().ToString());

    }
}
