using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EMMath;

public class MyCamera : MonoBehaviour
{
    private MyTransform myTransform;
    private GameObject target;
    private MyVector3 targetPosition;
    private float distance = 20.0f;
    private bool isMoving;
    
    // Start is called before the first frame update
    void Start()
    {
        myTransform = gameObject.GetComponent<MyTransform>();
        targetPosition = new MyVector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            MyVector3 relativeDistance = myTransform.position - targetPosition;
            MyVector3 yRotation = new MyVector3(0, Input.GetAxis("Mouse X"), 0);
            MyVector3 newPosition = MyQuaternion.RotateVector(new MyQuaternion(0.03f, yRotation), relativeDistance);
            newPosition.y += Input.GetAxis("Mouse Y");
            distance = Mathf.Clamp(distance - Input.mouseScrollDelta.y, 1.0f, 100.0f);
            newPosition.y = Mathf.Clamp(newPosition.y, -0.8f * distance, 0.8f * distance);
            myTransform.position = newPosition.Normalise() * distance;
        }
        myTransform.rotation.SetMatrix(MyVector3.LookAt(myTransform.position.Normalise(),targetPosition));
    }
}
