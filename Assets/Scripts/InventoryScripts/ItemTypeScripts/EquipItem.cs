using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Dictionary<string, int> EquipItemStats()
    {
        var equiPstats = new Dictionary<string, int>
        {
            { "Attack Speed : ", AttackSpeed },
            { "Critical Chance : ", CriticalChance },
            { "Critical Damage : ", CriticalDamage },
            { "AllStat : ", Allstat },
            { "Str : ", Str },
            { "Dex : ", Dex },
            { "Int : ", Int },
            { "Luk : ", Luk }
        };
        return equiPstats;
    }
}


