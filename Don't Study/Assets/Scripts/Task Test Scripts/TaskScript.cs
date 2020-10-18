using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskScript : MonoBehaviour
{
    public GameObject player;
    int button;
    public GameObject button1;
    public GameObject button2;


    void Start()
    {
        //gameObject.SetActive(false);
        button = 0;
    }

    //all input here
    void Update()
    {


    }

    public void activate()
    {
        gameObject.SetActive(true);
        button = 0;
        Reappear();
    }

    public void CloseTask()
    {
        button++;
        if (button >= 2)
        {
            gameObject.SetActive(false);
            player.GetComponent<PlayerControlllerTask>().move();
            button = 0;
        }
    }
public void Reappear()
    {
        button1.SetActive(true);
        button2.SetActive(true);

    }
}
