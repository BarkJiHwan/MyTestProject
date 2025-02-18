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
            if (0 <= dropChance) //�ϴ� 100% ��� �ǵ��� ��������
            {
                ItemInfo DropItem = ItemFactory.CreateItem(dropItem);
                GameObject itemObject = Instantiate(DropItem.itemPrefab, monster.transform.position, Quaternion.identity);
                ItemPickUp itemPickUp = itemObject.GetComponent<ItemPickUp>();
                if (itemPickUp != null)
                {
                    itemPickUp.itemInfo = DropItem; // ������ ���� �Ҵ�
                    Debug.Log(DropItem.name);
                }
                else
                {
                    Debug.Log("ItemPickUP�� ������ ����");
                    Destroy(itemObject);
                }
            }
        }
    }
}
