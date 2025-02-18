using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConsumTyep
{ HealthPotion, ManaPotion, Elixir }
[CreateAssetMenu(fileName = "New Armor", menuName = "Items/3.Consum", order = 3)]
public class ConsumItem : ItemInfo
{
    public int hpRestored;
    public int manaRestores;
}
