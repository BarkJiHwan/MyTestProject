using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    public Text itemNameText;
    public Text itemDescriptionText;
    public Image itemImage;

    public Text damages;
    public Text defense;
    public Text Hp;
    public Text Mp;

    public Text Allstate;
    public Text Str;
    public Text Dex;
    public Text Con;
    public Text Int;
    public Text Wis;
    public Text Luk;

    public Text HpRecovery;
    public Text MpRecovery;

    public Text FireResi;
    public Text ColdResi;
    public Text LightResi;

    public Text Price;


    public void ShowTooltip(ItemInfo itemInfo)
    {

        itemNameText.text = itemInfo.name;

        itemDescriptionText.text = itemInfo.description;
        itemImage.sprite = itemInfo.itemSprite;
        
        //damages.text = itemInfo.damages.ToString();
        //defense.text = itemInfo.defense.ToString();
        //Hp;
        //Mp;

        //Allstate;
        //Str;
        //Dex;
        //Con;
        //Int;
        //Wis;
        //Luk;

        //HpRecovery;
        //MpRecovery;

        //FireResi;
        //ColdResi;
        //LightResi;

        //Price;
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