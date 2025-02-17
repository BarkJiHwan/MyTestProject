using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemInfo itemInfo;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
        }
    }
}
