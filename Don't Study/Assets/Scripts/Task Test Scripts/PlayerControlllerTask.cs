using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlllerTask : MonoBehaviour
{
    public Rigidbody2D rb;
    public float MovementSpeed;

    public GameObject taskPopup;
    bool canMove;
    Vector2 velocity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//defines the rigidbody we'll be using
        taskPopup.SetActive(false);
        canMove = true;
    }

    //all input here
    void Update()
    {
        if (canMove)
        {
            Vector2 MovementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            velocity = MovementDirection.normalized * MovementSpeed;
        }
        else
        {
            velocity = Vector2.zero;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            canMove = false;
            taskPopup.GetComponent<TaskScript>().activate();
        }

    }

    //all movement here
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    public void move()
    {
        canMove = true;
    }
}
