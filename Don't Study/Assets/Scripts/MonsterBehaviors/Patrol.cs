using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed = 200f;
    [SerializeField]
    Transform[] nodes;
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

        rb.AddForce(direction * speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, nodes[j].position) < 0.1f)
        {
            i++;
        }
    }
}
