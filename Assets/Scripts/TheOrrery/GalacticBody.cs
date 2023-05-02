using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EMMath;

public class GalacticBody : MonoBehaviour
{
    public MyTransform myTransform;
    public Orbit orbit;
    public MySphereCollision collision;
    public List<GameObject> colliders;
    public float years;
    public float size;
    public float yearsPerMinute;
    public MyVector3 rotationAxis;
    public float rotationScale;
    private bool hasOrbit = false;
    private bool blowUp = false;

    void Start()
    {
        myTransform = gameObject.GetComponent<MyTransform>();
        collision = gameObject.GetComponent<MySphereCollision>();
        colliders = new List<GameObject>();
        rotationScale = 1;
        size = 1;
        rotationAxis = new MyVector3(0f, 90f, 0f);
        if (orbit != null)
        {
            hasOrbit = true;
            orbit = orbit.gameObject.GetComponent<Orbit>();
            myTransform.position = orbit.GetOrbitPosition(0);
        }
    }

    void Update()
    {
        colliders = collision.CheckCollisions();
        if (colliders.Count != 0)
        {
            foreach (GameObject x in colliders)
            {
                x.GetComponent<GalacticBody>().blowUp = true;
            }
            blowUp = true;
        }

        collision.centre = myTransform.position;

        if (hasOrbit)
        {
            years += yearsPerMinute / 60 * Time.deltaTime;
            myTransform.position = orbit.GetOrbitPosition(years);
        }
        
        MyVector3 newRotation = MyQuaternion.RotateVector(rotationAxis.ToQuaternion(),new MyVector3(0f, 90f, 0f));
        myTransform.rotation.AddAngle(newRotation * rotationScale * Time.deltaTime);
        myTransform.scale = new MyVector3(size, size, size);
        if (blowUp)
        {
            Destroy(this.gameObject);
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
