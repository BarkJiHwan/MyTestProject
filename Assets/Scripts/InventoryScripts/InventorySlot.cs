using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ItemInfo itemInfo;
    public Image image;
    public ItemTooltip itemTooltip;
    Transform panel;

    private void Start()
    {
        panel = transform.parent;
    }
    public void AddItem(ItemInfo newItem)
    {
        itemInfo = newItem;
        image.sprite = itemInfo.itemSprite;
        image.enabled = true;
    }
    public void ClearSlot()
    {
        itemInfo = null;
        image.sprite = null;
        image.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (itemInfo != null)
        {
            switch (itemInfo.itemType)
            {
                case ItemType.EquipItem:
                    itemTooltip.ShowTooltip(itemInfo);
                    break;
            }
        }
        itemTooltip.transform.position = eventData.position;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (itemInfo != null)
        {
            switch (itemInfo.itemType)
            {
                case ItemType.EquipItem:
                    itemTooltip.HideTooltip();
                    break;
            }
        }
    }    
}