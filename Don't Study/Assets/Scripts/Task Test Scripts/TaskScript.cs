using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskScript : MonoBehaviour
{
    public GameObject taskPopup;
    bool canMove;
    int button;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;

    void Start()
    {
        taskPopup.SetActive(false);
        canMove = true;
        button = 0;
    }

    //all input here
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            taskPopup.SetActive(true);
            canMove = false;
            taskPopup.GetComponent<TaskScript>().Reappear();
        }

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
public void Reappear()
    {
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        button4.SetActive(true);
    }
}
