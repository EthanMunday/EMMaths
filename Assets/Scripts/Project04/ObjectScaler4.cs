using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EMMath;

public class ObjectScaler4 : MonoBehaviour
{
    public Camera camera;
    public MeshFilter mf;
    MyVector3 forward;
    MyVector3 up;
    MyVector3 right;
    MyVector3[] vertices;
    float yawChange;

    void Start()
    {
        forward = new MyVector3(transform.position - camera.gameObject.transform.position);
        right = MyVector3.CrossProduct(new MyVector3(0,1,0), forward);
        up = MyVector3.CrossProduct(forward, right);
        vertices = new MyVector3[mf.mesh.vertexCount];
        for (int x = 0; x < mf.mesh.vertices.Length; x++)
        {
            vertices[x] = new MyVector3(mf.mesh.vertices[x]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        yawChange += Time.deltaTime;
        Vector3[] newVertices = new Vector3[vertices.Length];

        MyMatrix4x4 rotMatrix = new MyMatrix4x4(
            new MyVector3(Mathf.Cos(yawChange),0,-Mathf.Sin(yawChange)),
            new MyVector3(0,1,0),
            new MyVector3(Mathf.Sin(yawChange),0,Mathf.Cos(yawChange)),
            new MyVector3(0,0,0)
            );

        MyMatrix4x4 scaleMatrix = new MyMatrix4x4(
            new MyVector3(2 + Mathf.Sin(yawChange * 2), 0, 0),
            new MyVector3(0, 2 + Mathf.Sin(yawChange * 2), 0),
            new MyVector3(0, 0, 2 + Mathf.Sin(yawChange * 2)),
            new MyVector3(0, 0, 0)
            );

        MyMatrix4x4 transMatrix = new MyMatrix4x4(
            new MyVector4(1, 0, 0),
            new MyVector4(0, 1, 0),
            new MyVector4(0, 0, 1),
            new MyVector4(Mathf.Sin(yawChange) * 5, 0, 0)
            );
        for (int x = 0; x < vertices.Length; x++)
        {
            newVertices[x] = (transMatrix * new MyVector4((scaleMatrix * (rotMatrix * vertices[x])))).UnityVector();
        }
        Debug.Log(mf.mesh.vertices[0]);
        mf.mesh.vertices = newVertices;
        mf.mesh.RecalculateNormals();
        mf.mesh.RecalculateBounds();
    }
}
