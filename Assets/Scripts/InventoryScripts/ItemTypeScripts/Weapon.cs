using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HandType
{ 
    한손, 양손
}
public enum WeaponType
{ 
    검, 
    활, 
    스태프 
}
[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
public class Weapon : EquipItemItem
{
    public HandType handType;
    public WeaponType weaponType;
    public int range;
    public int damage;
}
