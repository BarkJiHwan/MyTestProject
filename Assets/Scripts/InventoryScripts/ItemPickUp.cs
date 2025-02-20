using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] private IItemProduct item;
    public IItemProduct Item { get => item; set => item = value; }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
        }
    }

//    void PickUp()
//    {
//        Debug.Log("Picking up " + item.Name);

//        // 아이템을 인벤토리에 추가
//        bool wasPickedUp = InventoryManager.Instance.AddItemToInventory(Item);

//        if (wasPickedUp)
//        {
//            Destroy(gameObject); // 아이템 오브젝트 제거
//        //}
//    }
//}
}
