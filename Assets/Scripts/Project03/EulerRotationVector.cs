using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EMMath;

public class EulerRotationVector : MonoBehaviour
{
    public EulerMovement x;

    // Update is called once per frame
    void Update()
    {
        transform.position = MyVector3.EulerAnglestoDirection(x.eulerAngles, true).UnityVector() * 3 + x.transform.position;
    }
}
