using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EMMath;

public class GalacticBody : MonoBehaviour
{
    public MyTransform myTransform;
    public Orbit orbit;
    public int orbitIndex;
    public float years;
    public float yearsPerMinute;

    void Start()
    {
        myTransform = gameObject.GetComponent<MyTransform>();
        if (orbit != null)
        {
            orbit = orbit.gameObject.GetComponents<Orbit>()[orbitIndex];
            myTransform.position = orbit.GetOrbitPosition(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        years += yearsPerMinute / 60 * Time.deltaTime;
        myTransform.position = orbit.GetOrbitPosition(years);
    }
}
