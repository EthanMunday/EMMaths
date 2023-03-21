using System.Collections;
using System.Collections.Generic;
using EMMath;
using UnityEngine;

public class Rotater06 : MonoBehaviour
{
    public Midpoint06 mid;
    private MyVector3 midPoint;
    float angle;
    MyQuaternion quartRotater1 = new MyQuaternion(0, new MyVector3(1, 0, 0));
    MyQuaternion quartRotater2 = new MyQuaternion(0.03f, new MyVector3(1, 0, 0));

    private void Start()
    {
        mid = FindObjectOfType<Midpoint06>();
        midPoint = new MyVector3(mid.transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        angle = Time.deltaTime;
        MyVector3 locationVector = new MyVector3(transform.position - midPoint.UnityVector());
        MyQuaternion quartRotater = new MyQuaternion(angle * 20, new MyVector3(1, 0.4f, 0.7f), true);
        locationVector = MyQuaternion.RotateVector(quartRotater, locationVector);
        Debug.Log(locationVector.x + " " + locationVector.y + " " + locationVector.z);
        transform.position = (midPoint + locationVector).UnityVector();

        //angle += Time.deltaTime / 10;
        //MyVector3 locationVector = new MyVector3(transform.position - midPoint.UnityVector());
        //MyQuaternion slerpRotater = MyQuaternion.Slerp(quartRotater1, quartRotater2, angle);
        //locationVector = MyQuaternion.RotateVector(slerpRotater, locationVector);
        //transform.position = (midPoint + locationVector).UnityVector();
    }
}
