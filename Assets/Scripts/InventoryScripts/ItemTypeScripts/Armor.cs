using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArmorType
{ 
    Helmet, Armor, Gloves, Boots, Shield, Ring, Necklace
}

[CreateAssetMenu(fileName = "New Armor", menuName = "Items/2.Armor", order = 2)]
public class Armor : EquipItem
{
    public ArmorType armorType;
    public int defense;
    public int moveSpeed;
    public int resistance;
    public int Hp;
    public int Mp;
}
