using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory
{
    public static T CreateItem<T>(T itemTemplate) where T : ItemInfo
    {
        T newItem = ScriptableObject.Instantiate(itemTemplate);
        return newItem;
    }
}

