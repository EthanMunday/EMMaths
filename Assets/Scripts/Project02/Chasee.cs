using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EMMath;

public class Chasee : MonoBehaviour
{
    public MyVector3 position;
    public MyVector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = position.UnityVector();
    }

    private void Update()
    {
        velocity = new MyVector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).Normalise();
        transform.position += velocity.UnityVector()  * Time.deltaTime * 4.0f;
        position = new MyVector3(transform.position);
    }
}
