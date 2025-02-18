using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HandType
{ 
    Onehanded, Twohanded
}
public enum WeaponType
{ 
    Sword, Bow, Staff
}
public class Weapon : EquipItem
{
    public HandType handType;
    public WeaponType weaponType;
    public int range;
    public int damage;
}
