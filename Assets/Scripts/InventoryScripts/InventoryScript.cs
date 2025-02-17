using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class InventoryScript : MonoBehaviour
{//아이템, 스킬, 퀘스트창 등등 판넬에서 이동 가능한 인터페이스들 둘 예정이니 클래스 이름 변경하자
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