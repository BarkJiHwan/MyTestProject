using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class InventoryScript : MonoBehaviour
{//������, ��ų, ����Ʈâ ��� �ǳڿ��� �̵� ������ �������̽��� �� �����̴� Ŭ���� �̸� ��������
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