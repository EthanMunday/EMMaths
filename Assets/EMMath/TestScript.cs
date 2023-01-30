using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EMMath;

public class TestScript : MonoBehaviour
{
    public MyVector2 vector2;
    public MyVector3 vector3;
    public MyVector4 vector4;

    private void Start()
    {
        InvokeRepeating("Report", 0.0f, 3.0f);
    }

    public void Report()
    {
        //Add Test
        //Debug.Log("Vector 2: " + vector2.UnityVector() + " +3: " + (vector2 + 3).UnityVector() + " Double: " + (vector2 + vector2).UnityVector());
        //Debug.Log("Vector 3: " + vector3.UnityVector() + " +3: " + (vector3 + 3).UnityVector() + " Double: " + (vector3 + vector3).UnityVector());
        //Debug.Log("Vector 4: " + vector4.UnityVector() + " +3: " + (vector4 + 3).UnityVector() + " Double: " + (vector4 + vector4).UnityVector());

        //Subtract Test
        //Debug.Log("Vector 2: " + vector2.UnityVector() + " -3: " + (vector2 - 3).UnityVector() + " Zero: " + (vector2 - vector2).UnityVector());
        //Debug.Log("Vector 3: " + vector3.UnityVector() + " -3: " + (vector3 - 3).UnityVector() + " Zero: " + (vector3 - vector3).UnityVector());
        //Debug.Log("Vector 4: " + vector4.UnityVector() + " -3: " + (vector4 - 3).UnityVector() + " Zero: " + (vector4 - vector4).UnityVector());

        //Multiply Test
        //Debug.Log("Vector 2: " + vector2.UnityVector() + " *3: " + (vector2 * 3).UnityVector());
        //Debug.Log("Vector 3: " + vector3.UnityVector() + " *3: " + (vector3 * 3).UnityVector());
        //Debug.Log("Vector 4: " + vector4.UnityVector() + " *3: " + (vector4 * 3).UnityVector());

        //Divide Test
        //Debug.Log("Vector 2: " + vector2.UnityVector() + " /3: " + (vector2 / 3).UnityVector());
        //Debug.Log("Vector 3: " + vector3.UnityVector() + " /3: " + (vector3 / 3).UnityVector());
        //Debug.Log("Vector 4: " + vector4.UnityVector() + " /3: " + (vector4 / 3).UnityVector());

        //Length Test
        //Debug.Log("Vector 2: " + vector2.UnityVector() + " Len: " + vector2.Length() + " LenSq: " + vector2.LengthSq());
        //Debug.Log("Vector 3: " + vector3.UnityVector() + " Len: " + vector3.Length() + " LenSq: " + vector3.LengthSq());
        //Debug.Log("Vector 4: " + vector4.UnityVector() + " Len: " + vector4.Length() + " LenSq: " + vector4.LengthSq());

        //Normalise Test
        //Debug.Log("Vector 2: " + vector2.UnityVector().x + " Norm: " + vector2.Normalise().x);
        //Debug.Log("Vector 3: " + vector3.UnityVector().x + " Norm: " + vector3.Normalise().x);
        //Debug.Log("Vector 4: " + vector4.UnityVector().x + " Norm: " + vector4.Normalise().x);
    }
}
