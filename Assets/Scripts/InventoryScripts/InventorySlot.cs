using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ItemInfo itemInfo;
    public ItemTooltip itemTooltip;

    private Transform panel;
    private RawImage RawImage;
    private void Start()
    {
        RawImage = gameObject.GetComponent<RawImage>();        
        panel = transform.parent;
    }
    public void AddItem(ItemInfo newItem)
    {
        itemInfo = newItem;
        RawImage.texture = newItem.itemSprite.texture;
        RawImage.enabled = true;
    }
    public void ClearSlot()
    {
        itemInfo = null;
        RawImage.texture = null;
        RawImage.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //if (itemInfo != null)
        //{
        //    switch (itemInfo.itemType)
        //    {
        //        case ItemType.EquipItem:
        //            itemTooltip.ShowTooltip(itemInfo);
        //            break;
        //        case ItemType.ConsumItem:
        //            itemTooltip.ShowTooltip(itemInfo);
        //            break;
        //    }
        //}
        itemTooltip.ShowTooltip(itemInfo);
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