using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EMMath;

public class Chaser : MonoBehaviour
{
    public MyVector3 position;
    public Chasee target;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = position.UnityVector();
        InvokeRepeating("Report", 0.0f, 3.0f);
    }

    private void Update()
    {
        MyVector3 lookAt = (target.position - position);
        if (MyVector3.DotProduct(lookAt,target.velocity,true) > 0.5)
        {
            MyVector3 direction = (target.position - position).Normalise();
            position = position + (direction * Time.deltaTime * 2.0f);
            transform.position = position.UnityVector();
        }
    }

    void Report()
    {
        Vector3 distance = target.position.UnityVector() - position.UnityVector();
        Debug.Log("Pos: " + position.UnityVector() + " Distance from Target: " + distance);
    }
}
