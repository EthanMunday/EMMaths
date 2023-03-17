using System.Collections;
using System.Collections.Generic;
using EMMath;
using UnityEngine;

public class Rotater06 : MonoBehaviour
{
    public Midpoint06 mid;
    private MyVector3 midPoint;
    float angle;
    MyQuarternion quartRotater1 = new MyQuarternion(0, new MyVector3(1, 0, 0));
    MyQuarternion quartRotater2 = new MyQuarternion(0.03f, new MyVector3(1, 0, 0));

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
        MyQuarternion quartRotater = new MyQuarternion(angle * 20, new MyVector3(1, 0.4f, 0.7f), true);
        locationVector = MyQuarternion.RotateVector(quartRotater, locationVector);
        Debug.Log(locationVector.x + " " + locationVector.y + " " + locationVector.z);
        transform.position = (midPoint + locationVector).UnityVector();

        //angle += Time.deltaTime / 10;
        //MyVector3 locationVector = new MyVector3(transform.position - midPoint.UnityVector());
        //MyQuarternion slerpRotater = MyQuarternion.Slerp(quartRotater1, quartRotater2, angle);
        //locationVector = MyQuarternion.RotateVector(slerpRotater, locationVector);
        //transform.position = (midPoint + locationVector).UnityVector();
    }
}
