using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed = 200f;
    //public float waitTime = 1f;
    [SerializeField]
    Transform[] nodes;
    Rigidbody2D rb;
    int randomNode, i = 0;
    //float wait;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //wait = waitTime;
        //randomNode = Random.Range(0, nodes.Length);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, nodes[randomNode].position, speed * Time.deltaTime);

        int j = i % nodes.Length;
        Vector2 direction = nodes[j].position - transform.position;
        direction = direction.normalized;

        rb.AddForce(direction * speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, nodes[j].position) < 0.01f)
        {
            i++;
            //if (wait <= 0f)
            //{
            ////randomNode = Random.Range(0, nodes.Length);
            //    wait = waitTime;
            //}
            //else
            //    wait -= Time.deltaTime;
        }
    }
}
