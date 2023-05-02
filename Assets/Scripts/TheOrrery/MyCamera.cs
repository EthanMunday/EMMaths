using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EMMath;

public class MyCamera : MonoBehaviour
{
    private MyTransform myTransform;
    private GameObject target;
    private MyVector3 targetPosition;
    private MyVector3 relativeDistance;
    private float distance = 20.0f;
    private bool hasTarget = false;
    private RaycastHit hitObject;
    private float lerpTimer = 1.0f;

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
            if (hasTarget)
            {
                ResetTarget();
            }

            MouseRotationUpdate();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            MySphereCollision[] otherSpheres = FindObjectsOfType<MySphereCollision>();
            bool newTarget = false;
            foreach (MySphereCollision x in otherSpheres)
            {
                if (x.IsColiding(myRay, new MyVector3(transform.position)))
                {
                    newTarget = true;
                    hasTarget = true;
                    target = x.gameObject;
                    targetPosition = target.GetComponent<MyTransform>().position;
                    relativeDistance = new MyVector3(0f, 10f, -20f);
                    myTransform.rotation.SetAngle(new MyVector3(22.5f,0f,0f));

                    break;
                }
            }

            if (!newTarget)
            {
                ResetTarget();
            }
        }
        if (hasTarget)
        {
            if (target == null)
            {
                ResetTarget();
            }
            else
            {
                targetPosition = target.GetComponent<MyTransform>().position;
                myTransform.position = targetPosition + relativeDistance;
            }
        }

        else
        {
            myTransform.rotation.SetMatrix(MyVector3.LookAt(myTransform.position.Normalise(),targetPosition));
        }

    }

    public void ResetTarget()
    {
        hasTarget = false;
        targetPosition = new MyVector3();
        MouseRotationUpdate();
    }

    public void MouseRotationUpdate()
    {
        relativeDistance = myTransform.position - targetPosition;
        MyVector3 yRotation = new MyVector3(0, Input.GetAxis("Mouse X"), 0);
        MyVector3 newPosition = MyQuaternion.RotateVector(new MyQuaternion(0.03f, yRotation), relativeDistance);
        newPosition.y += -Input.GetAxis("Mouse Y") * (distance / 30);
        distance = Mathf.Clamp(distance - Input.mouseScrollDelta.y, 1.0f, 100.0f);
        float yModifier = Mathf.Cos((relativeDistance.y * relativeDistance.y) / (distance * distance));
        newPosition.y = Mathf.Clamp(newPosition.y, -0.5f * distance, 0.5f * distance);
        myTransform.position = newPosition.Normalise() * (distance * yModifier);
    }
}
