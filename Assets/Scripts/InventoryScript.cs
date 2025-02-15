using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class InventoryScript : MonoBehaviour
{
    public GameObject inven;    

    private void Start()
    {
        inven.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inven.SetActive(!inven.activeSelf);
        }
    }
}