using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EMMath;

public class TargetObject : MonoBehaviour
{
    public MyVector3 position;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = position.UnityVector();
    }
}
