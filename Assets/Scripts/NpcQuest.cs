using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class NpcQuest : MonoBehaviour
{
    public GameObject player;
    float range = 3f;
    float dist;
    Quaternion tor;
    
    void Start()
    {
        tor = transform.rotation;
    }    
    void Update()
    {        
        dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist < range)
        {
            LookAtPlayer();
        }
        else
        {
            transform.rotation = tor;
        }
    }
    void LookAtPlayer()
    {
        Vector3 vr = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(vr);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
