using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EMMath;

public class Orbit : MonoBehaviour
{
    public float radius = 0.0f;
    public MyVector3 axis = new MyVector3(0.0f, 90.0f, 0.0f);
    public MyTransform myTransform;
    [HideInInspector] public GalacticBody body;
    [HideInInspector] public bool hasBody = false;
    private LineRenderer gizmoUI;

    private void Start()
    {
        myTransform = GetComponent<MyTransform>();
        gizmoUI = GetComponent<LineRenderer>();
        if (body != null)
        {
            hasBody = true;
        }
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    GalacticBody newBody = CreateBody(Random.Range(5f,20f));
        //    Orbit newOrbit = newBody.CreateOrbit(7f, new MyVector3(Random.Range(-90, 90f), 90f, Random.Range(-90, 90f)));
        //    int moons = Random.Range(1, 5);
        //    float moonspeed = Random.Range(60, 100f);
        //    for (int x = 0; x < moons; x++)
        //    {
        //        GalacticBody newBody2 = newOrbit.CreateBody(moonspeed);
        //        newBody2.years = (1.0f / moons) * x;
        //    }
        //}

        if (hasBody)
        {
            myTransform.position = body.myTransform.position;
        }
        axis.AngleClamp();

        gizmoUI.positionCount = Mathf.Clamp(((int)radius) * 10, 20, ((int)radius) * 10);
        for (int x = 0; x < gizmoUI.positionCount; x++)
        {
            float radians = ((float)x / gizmoUI.positionCount);
            gizmoUI.SetPosition(x, (GetOrbitPosition(radians)).UnityVector());
        }
    }

    public MyVector3 GetOrbitPosition(float progress)
    {
        progress *= 2 * Mathf.PI;
        MyVector3 axisStart = MyVector3.EulerAnglestoDirection(axis, true) * radius;
        return myTransform.position + MyQuaternion.RotateVector(new MyQuaternion(progress, axis, true), axisStart);
    }

    public void SetBody(GalacticBody newBody)
    {
        myTransform = GetComponent<MyTransform>();
        gizmoUI = GetComponent<LineRenderer>();
        hasBody = true;
        body = newBody;
        radius = 5.0f;
    }

    public GalacticBody CreateBody(float inYearsPerMinute)
    {
        GameObject newObject = Instantiate(Resources.Load("Planet")) as GameObject;
        GalacticBody newBody = newObject.GetComponent<GalacticBody>();
        newBody.SetOrbit(this);
        newBody.yearsPerMinute = inYearsPerMinute;
        return newBody;
    }
}
