using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float FollowSpeed;

    
    // Update is called once per frame
    void Update()
    {
        Vector3 TargetPos = target.position;
        TargetPos.z = -10f;
        transform.position = Vector2.Lerp(transform.position, TargetPos, FollowSpeed * Time.deltaTime);
    }
}
