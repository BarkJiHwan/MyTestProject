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
    // Start is called before the first frame update
    void Start()
    {        
        tor = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //if (colls != null)
        //{
        //    LookAtPlayer();
        //}
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
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.tag == "Player")
    //    {
    //        Quaternion rot = Quaternion.LookRotation(-collision.transform.forward);
    //        transform.rotation = rot;
    //    }
    //}
}
