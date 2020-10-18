using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField]
    LayerMask obstacles;
    private Mesh cone;
    Vector3 origin;
    float startAngle;
    float fov;
    float viewDist;
    //Vector3 startPos;
    //Vector3 offset;
    private void Start()
    {
        cone = new Mesh();
        GetComponent<MeshFilter>().mesh = cone;
        //startPos = transform.position;
        origin = Vector3.zero;
        fov = 90f;
        viewDist = 5f;
    }

    private void LateUpdate()
    {
        int rayCount = 50;
       // offset = transform.position - startPos;
       // startPos = origin;
        float angle = startAngle;
        float incrAngle = fov / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];//1 for origing and 1 for the 0 ray
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D hit = Physics2D.Raycast(origin, VectorFromAngle(angle), viewDist, obstacles);
            Debug.DrawRay(origin, VectorFromAngle(angle));
            if (hit.collider == null)
            {
                //no hit
                vertex = origin + VectorFromAngle(angle) * viewDist;
            }
            else
            {
                vertex = hit.point;//Point where it hit object
            }
            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triIndex + 0] = 0;
                triangles[triIndex + 1] = vertexIndex - 1;
                triangles[triIndex + 2] = vertexIndex;
                triIndex += 3;
            }

            vertexIndex++;
            angle -= incrAngle;//Want to go clockwise
        }

        cone.vertices = vertices;
        cone.uv = uv;
        cone.triangles = triangles;
    }

    public Vector3 VectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
    public float AngleFromVector(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0)
            n += 360;
        return n;
    }

    public void SetOrigin(Vector3 og)
    {
        origin = og;   
    }
    public void SetDirection(Vector3 dir)
    {
        startAngle = AngleFromVector(dir) + fov / 2f;
    }
    public void SetFOV(float view)
    {
        fov = view;
    }
    public void SetViewDistance(float dist)
    {
        viewDist = dist;
    }
}
