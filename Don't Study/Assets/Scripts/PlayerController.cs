using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator MyAnimator;
    public Rigidbody2D rb;

    public float MovementSpeed = 1f;
    
    Vector2 velocity;
    
    

    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//defines the rigidbody we'll be using
    }

    //all input here
    void Update()
    {
        

        Vector2 MovementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        velocity = MovementDirection.normalized * MovementSpeed;

        MyAnimator.SetFloat("Horizontal", velocity.x);
        MyAnimator.SetFloat("Vertical", velocity.y);
        MyAnimator.SetFloat("Speed", velocity.sqrMagnitude);
    }

    //all movement here
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    

    
}
