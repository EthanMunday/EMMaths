using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EMMath;

public class EulerMovement : MonoBehaviour
{
    public MyVector3 eulerAngles = new MyVector3();
    private MyVector3 right;
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            eulerAngles.x += Time.deltaTime * 30;
        }

        if (Input.GetKey(KeyCode.O))
        {
            eulerAngles.y += Time.deltaTime * 30;
        }

        if (Input.GetKey(KeyCode.P))
        {
            eulerAngles.z += Time.deltaTime * 30;
        }
        
        transform.position += MyVector3.EulerAnglestoDirection(eulerAngles,true).UnityVector() * Time.deltaTime * Input.GetAxis("Vertical");
        right = eulerAngles + new MyVector3(0.0f, 90.0f);
        transform.position += MyVector3.EulerAnglestoDirection(right, true).UnityVector() * Time.deltaTime * Input.GetAxis("Horizontal");
        transform.eulerAngles = eulerAngles.UnityVector();
    }
}
