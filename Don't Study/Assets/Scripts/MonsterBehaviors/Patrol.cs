using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed = 200f;
    public bool inViewDist;
    public bool inViewAngle;
    public bool canSee;
    [SerializeField]
    Transform[] nodes;
    [SerializeField]
    FieldOfView cone;
    [SerializeField]
    Transform target;
    Rigidbody2D rb;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        int j = i % nodes.Length;
        Vector2 direction = nodes[j].position - transform.position;
        direction = direction.normalized;
        cone.SetDirection(direction);
        cone.SetOrigin(transform.position);

        rb.AddForce(direction * speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, nodes[j].position) < 0.1f)
        {
            i++;
        }

        inViewDist = Vector3.Distance(transform.position, target.position) < cone.viewDist;
        Vector3 dirToPlayer = (target.position - transform.position).normalized;
        inViewAngle = Vector3.Angle(cone.VectorFromAngle(cone.startAngle), dirToPlayer) < (cone.fov / 2f);

        //RaycastHit2D hit = Physics2D.Raycast(transform.position, dirToPlayer, cone.viewDist);
        //if (hit.collider != null)
        //{
        //    canSee = hit.collider.gameObject == GameObject.FindGameObjectWithTag("Player");
        //
        //}

    }
}