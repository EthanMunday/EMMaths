using System.Collections;
using System.Collections.Generic;
using EMMath;
using UnityEngine;

public class Rotater06 : MonoBehaviour
{
    public MyVector3 midPoint;
    float angle;
    MyQuarternion quartRotater1 = new MyQuarternion(0, new MyVector3(0, 1, 0));
    MyQuarternion quartRotater2 = new MyQuarternion(0.03f, new MyVector3(0, 1, 0));

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        //angle += Time.deltaTime;
        //MyVector3 locationVector = new MyVector3(transform.position - midPoint.UnityVector());
        //MyQuarternion quartRotater = new MyQuarternion(angle * 4, new MyVector3(0, 1, 0));
        //locationVector = MyQuarternion.RotateVector(quartRotater, locationVector);
        //transform.position = (midPoint + locationVector).UnityVector();

        angle += Time.deltaTime / 10;
        MyVector3 locationVector = new MyVector3(transform.position - midPoint.UnityVector());
        MyQuarternion slerpRotater = MyQuarternion.Slerp(quartRotater1, quartRotater2, angle);
        locationVector = MyQuarternion.RotateVector(slerpRotater, locationVector);
        transform.position = (midPoint + locationVector).UnityVector();
    }
}
