using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EMMath;

public class SphereChecking7 : MonoBehaviour
{
    [HideInInspector] MySphereCollision sphere;
    [HideInInspector] MyTransform transform;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<MyTransform>();
        sphere = GetComponent<MySphereCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        sphere.centre = transform.position;
        if (sphere.CheckCollisions().Count != 0)
        {
            Debug.Log(sphere.CheckCollisions()[0]);
        }
        //Debug.Log(sphere.CheckCollisions()[0]);
    }
}
