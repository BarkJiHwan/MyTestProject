using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemManager : MonoBehaviour
{
    private static ItemManager _instance;
    public static ItemManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ItemManager>();
                if (_instance == null)
                {
                    GameObject Itemmanger = new GameObject("ItemManager");
                    _instance = Itemmanger.AddComponent<ItemManager>();
                }
            }
            return _instance;
        }
    }


    [SerializeField] private List<ItemInfo> itemDatabase;

    private void Awake()
    {
        
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void MonsterDropItem(Monster monster)
    {
        foreach (var dropItem in monster.dropItems)
        {
            float dropChance = dropItem.dropRate * monster.CalcDrop(dropItem);
            if (0 <= dropChance) // �ϴ� 100% ��� �ǵ��� ��������
            {
                ItemInfo itemInfo = GetItemInfo(dropItem.name);
                if (itemInfo != null)
                {
                    var itemObject = Instantiate(itemInfo.itemPrefab, monster.transform.position, Quaternion.identity);
                    ItemProduct itemPickUp = itemObject.GetComponent<ItemProduct>() ?? itemObject.AddComponent<ItemProduct>();

                    if (itemPickUp != null)
                    {
                        itemPickUp.ItemInfo = itemInfo; // ������ ���� �Ҵ�
                        itemPickUp.SetInitialize(itemInfo);                        
                    }
                    else
                    {
                        Debug.LogError("ItemProduct ������Ʈ�� �߰��ϴµ� �����߽��ϴ�.");
                        Destroy(itemObject);
                    }
                }
                else
                {
                    Debug.LogError("������ ������ ã�� �� �����ϴ�: " + dropItem.name);
                }
            }
        }

    }
    private ItemInfo GetItemInfo(string itemName)
    {
        return itemDatabase.Find(item => item.name == itemName);
    }
}
