using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    EquipItem,
    ConsumItem,
    MiscItem,
    QusetItem
}
public enum ItemGrade
{
    Normal,
    Epic,
    Legendary,
    Mythical
}
public class ItemInfo : ScriptableObject
{
    public ItemType itemType;
    public ItemGrade itemGrade;
    public string name;
    public string itemDescription;
    public int price;
    public int count;
    
    public Sprite itemSprite;
}
