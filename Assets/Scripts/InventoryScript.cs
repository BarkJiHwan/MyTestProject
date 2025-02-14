using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class InventoryScript : MonoBehaviour
{
    public GameObject inven;
    private float checkInterval = 0.1f; // 0.1√  ∞£∞›

    private void Start()
    {        
        inven.SetActive(false);
        InvokeRepeating("CheckKey", 0f, checkInterval);
    }

    void CheckKey()
    {
        if (Input.GetKey(KeyCode.I))
        {
            inven.SetActive(!inven.activeSelf);
        }
    }

    void OnDisable()
    {
        CancelInvoke("CheckKey");
    }
}
