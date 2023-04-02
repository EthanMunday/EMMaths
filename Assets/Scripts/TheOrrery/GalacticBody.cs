using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EMMath;

public class GalacticBody : MonoBehaviour
{
    [HideInInspector] public MyTransform myTransform;
    [HideInInspector] public Orbit orbit;
    [HideInInspector] public float years;
    public float yearsPerMinute;
    private bool hasOrbit = false;

    void Start()
    {
        myTransform = gameObject.GetComponent<MyTransform>();
        if (orbit != null)
        {
            hasOrbit = true;
            orbit = orbit.gameObject.GetComponent<Orbit>();
            myTransform.position = orbit.GetOrbitPosition(0);
        }
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    CreateOrbit(Random.Range(2f,70f), new MyVector3(Random.Range(-90, 90f), 90f, Random.Range(-90, 90f)));
        //}

        if (hasOrbit)
        {
            years += yearsPerMinute / 60 * Time.deltaTime;
            myTransform.position = orbit.GetOrbitPosition(years);
        }
    }

    public void SetOrbit(Orbit newOrbit)
    {
        myTransform = gameObject.GetComponent<MyTransform>();
        hasOrbit = true;
        orbit = newOrbit;
        myTransform.position = orbit.GetOrbitPosition(0);
    }

    public Orbit CreateOrbit(float inRadius, MyVector3 inAxis)
    {
        GameObject newObject = Instantiate(Resources.Load("Orbit")) as GameObject;
        Orbit newOrbit = newObject.GetComponent<Orbit>();
        newOrbit.SetBody(this);
        newOrbit.axis = inAxis;
        newOrbit.radius = inRadius;
        return newOrbit;
    }
}
