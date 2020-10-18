using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimation : MonoBehaviour
{
    public Animator MonsterAnim;
    public PlayerController target;

    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = (target.transform.position - transform.position).normalized;
        MonsterAnim.SetFloat("Horizontal", direction.x);
        MonsterAnim.SetFloat("Vertical", direction.y);
        MonsterAnim.SetFloat("Speed", direction.sqrMagnitude);
    }
    //private 
}
