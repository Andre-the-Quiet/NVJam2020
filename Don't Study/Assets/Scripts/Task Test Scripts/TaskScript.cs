using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskScript : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Reappear()
    {
        button1.SetActive(true);
        button2.SetActive(true);
    }
}
