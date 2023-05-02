using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EMMath;

public class CameraChecker : MonoBehaviour
{
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray clickRay = camera.ScreenPointToRay(Input.mousePosition);

            MySphereCollision[] otherSpheres = FindObjectsOfType<MySphereCollision>();

            foreach (MySphereCollision x in otherSpheres)
            {
                if (x.IsColiding(clickRay, new MyVector3(transform.position)))
                {
                    break;
                }
            }
        }
    }
}
