using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public Animator transitionAnim;
    public bool teleported = false;
    public GameObject dest;
    public GameObject target;
    public AudioClip FX;
    public AudioSource FXsource;
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag ("Player"))
        {
            //Debug.Log("PLAYER");
            if (!teleported)
            {
                dest.GetComponent<TriggerEvent>().teleport();
                //Debug.Log("PRESSED");
                
                StartCoroutine(LoadScene(col));
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
    IEnumerator LoadScene(Collider2D col)
    {
        transitionAnim.SetTrigger("End");
        FXsource.PlayOneShot(FX);
        yield return new WaitForSeconds(0.3f);
        
        col.transform.position = dest.transform.position;
        transitionAnim.SetTrigger("Start");
    }
}
