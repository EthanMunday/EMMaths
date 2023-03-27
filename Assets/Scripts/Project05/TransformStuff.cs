using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EMMath;

public class TransformStuff : MonoBehaviour
{
    MyTransform myTransform;
    float change;

    void Start()
    {
        myTransform = gameObject.GetComponent<MyTransform>();
        change = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        change += Time.deltaTime;
        myTransform.position += new MyVector3(Mathf.Sin(change * 2) * 3, 0.0f, 0.0f) * Time.deltaTime;
        myTransform.rotation.AddEuler(new MyVector3(-1.0f,2.0f,-0.3f) * Time.deltaTime);
        myTransform.scale += new MyVector3(Mathf.Sin(change * 3), Mathf.Sin(change * 3), Mathf.Sin(change * 3)) * Time.deltaTime;
    }
}
