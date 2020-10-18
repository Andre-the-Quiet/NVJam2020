using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskScript : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public void Reappear()
    {
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        button4.SetActive(true);
    }
}
