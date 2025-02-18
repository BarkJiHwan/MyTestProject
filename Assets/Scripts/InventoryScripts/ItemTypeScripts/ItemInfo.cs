using System.Collections;
using System.Collections.Generic;
using System.Text;
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
public enum JobType
{
    AllClass,
    Warrior,
    Archer,
    Mage
}     
public class ItemInfo : ScriptableObject
{
    public ItemType itemType;
    public ItemGrade itemGrade;
    public string name;
    public string itemDescription;
    public int price;
    public int count;
    public int requiredLevel;
    public JobType requiredClass;
    public int requiredStrength;
    public int requiredDexterity;
    public int requiredIntelligence;
    public int requiredLuck;

    public Sprite itemSprite;
    public virtual void ShowMyInfo(StringBuilder stateBuilder)
    {
        stateBuilder.AppendLine($"Name: {name}");
        stateBuilder.AppendLine($"Type: {itemType}");
        stateBuilder.AppendLine($"Description: {itemDescription}");
        stateBuilder.AppendLine($"Price: {price}");
        stateBuilder.AppendLine($"Required: ");
        stateBuilder.AppendLine($"Level: {requiredLevel}");
        stateBuilder.AppendLine($"Class: {requiredClass}");
        stateBuilder.Append($"Str: {requiredStrength}");
        stateBuilder.AppendLine($"Dex: {requiredDexterity}");
        stateBuilder.Append($"Int: {requiredIntelligence}");
        stateBuilder.AppendLine($"Luck: {requiredLuck}");
    }
}

