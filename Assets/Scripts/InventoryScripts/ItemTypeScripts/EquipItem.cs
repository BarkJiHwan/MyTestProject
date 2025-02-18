using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "New EquipItem", menuName = "Items/1.Equip", order = 1)]
public class EquipItem : ItemInfo
{
    public int AttackSpeed;
    public int CriticalChance;
    public int CriticalDamage;
    public int Allstat;
    public int Str;
    public int Dex;
    public int Int;
    public int Luk;
        
    public override void ShowMyInfo(StringBuilder stateBuilder)
    {
        base.ShowMyInfo(stateBuilder);
        stateBuilder.AppendLine($"Attack Speed: {AttackSpeed}");
        stateBuilder.AppendLine($"Critical Chance: {CriticalChance}");
        stateBuilder.AppendLine($"Critical Damage: {CriticalDamage}");
        stateBuilder.AppendLine($"All Stat: {Allstat}");
        stateBuilder.AppendLine($"Strength: {Str}");
        stateBuilder.AppendLine($"Dexterity: {Dex}");
        stateBuilder.AppendLine($"Intelligence: {Int}");
        stateBuilder.AppendLine($"Luck: {Luk}");
    }
}

