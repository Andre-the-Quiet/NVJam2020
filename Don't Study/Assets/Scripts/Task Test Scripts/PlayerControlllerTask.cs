using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlllerTask : MonoBehaviour
{
    public Rigidbody2D rb;
    public float MovementSpeed;

    public GameObject taskPopup;
    bool canMove;
    int button;
    Vector2 velocity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//defines the rigidbody we'll be using
        taskPopup.SetActive(false);
        canMove = true;
        button = 0;
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
            taskPopup.SetActive(true);
            canMove = false;
            taskPopup.GetComponent<TaskScript>().Reappear();
        }

    }

    //all movement here
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    public void CloseTask()
    {
        button++;
        if (button >= 2)
        {
            taskPopup.SetActive(false);
            canMove = true;
            button = 0;
        }
    }
}
