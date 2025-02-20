using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class ItemProduct : MonoBehaviour, IItemProduct
{
    public ItemType ItemType { get; private set; }
    public ItemInfo ItemInfo { get; set; }
    private void Start()
    {
    }
    public void SetPosition(Vector3 Pos)
    {
        transform.position = Pos;
    }

    public void UseItem()
    {

    }

    public void SetInitialize(ItemInfo itemInfo)
    {
        ItemInfo = itemInfo;
        ItemType = itemInfo.itemType;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            PickUp();
        }
    }
    private void PickUp()
    {
        if (ItemInfo == null)
        {
            Debug.LogError("������ ������ �������� �ʾҽ��ϴ�.");
            return;
        }
        IItemProduct itemProduct = ItemFactory.CreateItem(ItemInfo);
        bool wasPickedUp = InventoryManager.Instance.AddItemToInventory(itemProduct);

        if (wasPickedUp)
        {
            Destroy(gameObject); // ������ ������Ʈ ����
        }
        else
        {
            Debug.Log("�κ��丮�� ���� á���ϴ�.");
        }
    }
}