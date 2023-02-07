using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EMMath;

public class TeleportObject : MonoBehaviour
{
    public MyVector3 position;
    public TargetObject target;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = position.UnityVector();
        InvokeRepeating("Report", 0.0f, 3.0f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 distance = target.position.UnityVector() - position.UnityVector();
            position = position + new MyVector3(distance);
            transform.position = position.UnityVector();
            Debug.Log("Moved to " + position.UnityVector());
        }
    }

    void Report()
    {
        Vector3 distance = target.position.UnityVector() - position.UnityVector();
        Debug.Log("Pos: " + position.UnityVector() + " Distance from Target: " + distance);
    }
}
