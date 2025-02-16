using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    EquipItem,
    ConsumItem,
    ExtaItem,
    QusetItem
    
}
[CreateAssetMenu(fileName = "New Item", menuName = "SOItem")]
public class ItemInfo : ScriptableObject
{    
    public string description;
    public Sprite itemSprite;
    public ItemType type;

    public int Damages;
    public int Defense;
    public int Hp;
    public int Mp;

    public int Allstate;
    public int Str;
    public int Dex;
    public int Con;
    public int Int;
    public int Wis;
    public int Luk;

    public int HpRecovery;
    public int MpRecovery;

    public int FireResi;
    public int ColdResi;
    public int LightResi;

    public int Price;
}
