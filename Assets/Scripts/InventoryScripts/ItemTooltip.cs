using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    public Text itemNameText;
    public Text itemTypeText;
    public Text itemDescriptionText;
    public Image itemImage;
    public Text Price;
    public Text equipItemText;

    private StringBuilder stateBuilder;

    private void Start()
    {
        stateBuilder = new StringBuilder();
        
}
    public void ShowTooltip(ItemInfo itemInfo)
    {
        itemNameText.text = itemInfo.name;
        itemTypeText.text = itemInfo.itemType.ToString();
        itemDescriptionText.text = "아이템 설명\n" + itemInfo.itemDescription;
        itemImage.sprite = itemInfo.itemSprite;
        Price.text = itemInfo.price.ToString();
        
        stateBuilder.Length = 0;

        if (itemInfo is EquipItem equipItem)
        { 
            Dictionary<string, int> equipmentStats = equipItem.EquipItemStats();
            foreach (var stat in equipmentStats)
            {
                stateBuilder.AppendLine($"{stat.Key}: {stat.Value}");
            }
        }
        equipItemText.text = stateBuilder.ToString();

        gameObject.SetActive(true);
        gameObject.GetComponent<Image>().raycastTarget = false;
        SetRaycastTargetForAllChildren(gameObject, false);
    }
    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    public void SetRaycastTargetForAllChildren(GameObject parent, bool value)
    {
        Text[] childImages = parent.GetComponentsInChildren<Text>();

        foreach (var img in childImages)
        {
            img.raycastTarget = value;
        }
    }
    
}