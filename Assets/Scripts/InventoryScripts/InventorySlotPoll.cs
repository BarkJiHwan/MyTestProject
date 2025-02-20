using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotPoll : MonoBehaviour
{
    [SerializeField] private InventorySlot slotPrefab;
    [SerializeField] private int poolSize = 100;

    void Awake()
    {
        InitializePool();
    }
    void InitializePool()
    {
        for(int i = 0; i < poolSize; i++)
        {
            InventorySlot slot = Instantiate(slotPrefab, transform);                       
        }
    }
}
