using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public Rigidbody2D rb;

    public float MovementSpeed = 1f;
    public Vector2 velocity;
    
    

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//defines the rigidbody we'll be using
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 MovementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        velocity = MovementDirection.normalized * MovementSpeed;
        
    }

    private void FixedUpdate()//all calls related to physics
    {
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }

    

    
}
