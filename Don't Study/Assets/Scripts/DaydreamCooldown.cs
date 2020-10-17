using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaydreamCooldown : MonoBehaviour
{
    public float CoolDown = 5f;
    public float CoolDownTimer;
    

    // Update is called once per frame
    void Update()
    {
        if(CoolDownTimer > 0)
        {
            CoolDownTimer -= Time.deltaTime;
        }
        if(CoolDownTimer < 0)
        {
            CoolDownTimer = 0;
        }
        if(Input.GetKeyDown(KeyCode.Space) && CoolDownTimer == 0)
        {
            for(int x =0; x < 5; x++)
            {
                print("DAYDREAM");
            }
            
            CoolDownTimer = CoolDown;
        }
    }
}
