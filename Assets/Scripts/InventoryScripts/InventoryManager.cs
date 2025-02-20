using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    [SerializeField] private List<IItemProduct> equipItems = new List<IItemProduct>();
    [SerializeField] private List<IItemProduct> consumItems = new List<IItemProduct>();
    [SerializeField] private List<IItemProduct> miscItems = new List<IItemProduct>();
    [SerializeField] private List<IItemProduct> questItems = new List<IItemProduct>();
    [SerializeField] private List<IItemProduct> allItems = new List<IItemProduct>();
    [SerializeField] private RectTransform deleteArea;//아이템 삭제영역

    [SerializeField] private Transform AllItemPanel;
    [SerializeField] private Transform equipPanel; // 장비 아이템 패널
    [SerializeField] private Transform consumPanel; // 소모품 아이템 패널
    [SerializeField] private Transform miscPanel; // 잡화 아이템 패널
    [SerializeField] private Transform questPanel; // 퀘스트 아이템 패널

    [SerializeField] private List<InventorySlot> AllItemSlots = new List<InventorySlot>();
    [SerializeField] private List<InventorySlot> equipSlots = new List<InventorySlot>();
    [SerializeField] private List<InventorySlot> consumSlots = new List<InventorySlot>();
    [SerializeField] private List<InventorySlot> miscSlots = new List<InventorySlot>();
    [SerializeField] private List<InventorySlot> questSlots = new List<InventorySlot>();

    [SerializeField] private InventorySlot slotPrefab;
    [SerializeField] private int poolSize = 100;

    
    public List<InventorySlot> AllitemSlots { get => AllItemSlots; set => AllItemSlots = value; }
    public List<InventorySlot> EquipSlots { get => equipSlots; set => equipSlots = value; }
    public List<InventorySlot> ConsumSlots { get => consumSlots; set => consumSlots = value; }
    public List<InventorySlot> MiscSlots { get => miscSlots; set => miscSlots = value; }
    public List<InventorySlot> QuestSlots { get => questSlots; set => questSlots = value; }


    public RectTransform DeleteArea => deleteArea;

    public Transform AllitemPanel { get => AllItemPanel; set => AllItemPanel = value; }
    public Transform EquipPanel { get => equipPanel; set => equipPanel = value; }
    public Transform ConsumPanel { get => consumPanel; set => consumPanel = value; }
    public Transform MiscPanel { get => miscPanel; set => miscPanel = value; }
    public Transform QuestPanel { get => questPanel; set => questPanel = value; }

    private void Awake()
    {
        //InitializePool(AllitemPanel);
        InitializePool(EquipPanel);
        InitializePool(ConsumPanel);
        InitializePool(MiscPanel);
        InitializePool(QuestPanel);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void CacheSlots(Transform panel, List<InventorySlot> slotList)
    {
        foreach (Transform slotTransform in panel)
        {
            InventorySlot slot = slotTransform.GetComponent<InventorySlot>();
            if (slot != null)
            {
                slotList.Add(slot);
            }
            else
            {
                Debug.LogWarning($"{slotTransform.name}에 InventorySlot 컴포넌트 없음");
            }
        }
    }
    void InitializePool(Transform panel)
    {
        for (int i = 0; i < poolSize; i++)
        {
            InventorySlot slot = Instantiate(slotPrefab, panel.transform);
        }
    }
    public bool AddItemToInventory(IItemProduct item)
    {
        switch (item.ItemType)
        {
            case ItemType.EquipItem:
                equipItems.Add(item);
                equipSlots[0].rawImage.texture = equipItems[0].ItemInfo.itemSprite.texture;
                break;
            case ItemType.ConsumItem:
                consumItems.Add(item);
                break;
            case ItemType.MiscItem:
                miscItems.Add(item);
                break;
            case ItemType.QusetItem:
                questItems.Add(item);
                break;
            default:
                return false;
        }
        allItems.Add(item);        
        return true;
    }

    public void RemoveItemFromInventory(InventorySlot slot)
    {        
        IItemProduct item = slot.item;
        if (item != null)
        {           

            switch (item.ItemType)
            {
                case ItemType.EquipItem:
                    equipItems.Remove(item);
                    allItems.Remove(item);
                    break;
                case ItemType.ConsumItem:
                    consumItems.Remove(item);
                    allItems.Remove(item);
                    break;
                case ItemType.MiscItem:
                    miscItems.Remove(item);
                    allItems.Remove(item);
                    break;
                case ItemType.QusetItem:
                    questItems.Remove(item);
                    allItems.Remove(item);
                    break;
                default:
                    allItems.Remove(item);
                    break;
            }
            slot.ClearSlot();
        }
    }
}