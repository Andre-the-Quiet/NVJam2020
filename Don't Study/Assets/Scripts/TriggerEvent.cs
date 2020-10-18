using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public Boolean EnterMap2 = false;
    public SpriteRenderer Map1;
    public SpriteRenderer Map2;
    public GameObject target;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag ("Player"))
        {
            if(EnterMap2 == false)
            {
                
                Map1.sortingOrder = -3;
                
            }
            if(EnterMap2 == true)
            {
                
                Map1.sortingOrder = -2;
                
            }
            
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.IsTouching(target.GetComponent<CapsuleCollider2D>()))
        {
            if(EnterMap2 == false)
            {
                EnterMap2 = true;
            }
            if (EnterMap2 ==true)
            {
                EnterMap2 = false;
            }
        }
    }
}
