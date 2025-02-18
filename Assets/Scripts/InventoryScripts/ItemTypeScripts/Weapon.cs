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
[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/1.Weapon", order = 1)]
public class Weapon : EquipItem
{
    public HandType handType;
    public WeaponType weaponType;
    public int range;
    public int damage;
}
