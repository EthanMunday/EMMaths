using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EMMath;

public class Orbit : MonoBehaviour
{
    public float radius;
    public MyVector3 axis;
    public MyVector3 location;
    [HideInInspector] public GalacticBody body;
    [HideInInspector] public bool hasBody;

    private void Start()
    {
        body = GetComponent<GalacticBody>();
        if (body != null)
        {
            hasBody = true;
        }
    }

    public MyVector3 GetOrbitPosition(float progress)
    {
        progress *= 2 * Mathf.PI;
        MyVector3 axisStart = MyVector3.EulerAnglestoDirection(axis, true) * radius;
        Debug.Log(axisStart.x + " " + axisStart.z);
        return location + MyQuaternion.RotateVector(new MyQuaternion(progress, axis, true), axisStart);
    }

    public Orbit(GalacticBody inBody, MyVector3 inAxis, float inRadius = 1.0f, float inSpeed = 10.0f)
    {
        body = inBody;
        location = body.myTransform.position;
        axis = inAxis;
        radius = inRadius;
        hasBody = true;

    }
    public Orbit(MyVector3 inLocation, MyVector3 inAxis, float inRadius = 1.0f, float inSpeed = 10.0f)
    {
        location = inLocation;
        axis = inAxis;
        radius = inRadius;
        hasBody = false;
    }

    private void Update()
    {
        if (hasBody)
        {
            location = body.myTransform.position;
        }
        axis.AngleClamp();
    }
}
