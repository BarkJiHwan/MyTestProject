using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HandType
{ 
    �Ѽ�, ���
}
public enum WeaponType
{ 
    ��, 
    Ȱ, 
    ������ 
}
[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
public class Weapon : EquipItemItem
{
    public HandType handType;
    public WeaponType weaponType;
    public int range;
    public int damage;
}
