using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public bool teleported = false;
    public GameObject dest;
    public GameObject target;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag ("Player"))
        {
            //Debug.Log("PLAYER");
            if (!teleported)
            {
                dest.GetComponent<TriggerEvent>().teleport();
                //Debug.Log("PRESSED");
                col.transform.position = dest.transform.position;
            }


        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            teleported = false;
        }
    }

    public void teleport()
    {
        teleported = true;
    }
}
