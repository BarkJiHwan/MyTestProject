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
            if (0 <= dropChance) // 일단 100% 드롭 되도록 설정했음
            {
                ItemInfo itemInfo = GetItemInfo(dropItem.name);
                if (itemInfo != null)
                {
                    var itemObject = Instantiate(itemInfo.itemPrefab, monster.transform.position, Quaternion.identity);
                    ItemProduct itemPickUp = itemObject.GetComponent<ItemProduct>() ?? itemObject.AddComponent<ItemProduct>();

                    if (itemPickUp != null)
                    {
                        itemPickUp.ItemInfo = itemInfo; // 아이템 정보 할당
                        itemPickUp.SetInitialize(itemInfo);                        
                    }
                    else
                    {
                        Debug.LogError("ItemProduct 컴포넌트를 추가하는데 실패했습니다.");
                        Destroy(itemObject);
                    }
                }
                else
                {
                    Debug.LogError("아이템 정보를 찾을 수 없습니다: " + dropItem.name);
                }
            }
        }

    }
    private ItemInfo GetItemInfo(string itemName)
    {
        return itemDatabase.Find(item => item.name == itemName);
    }
}
