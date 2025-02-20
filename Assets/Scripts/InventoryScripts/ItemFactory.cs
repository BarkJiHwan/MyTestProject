using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory
{
    public static IItemProduct CreateItem(ItemInfo itemInfo)
    {
        GameObject itemObject = new GameObject(itemInfo.name);
        ItemProduct itemProduct = itemObject.AddComponent<ItemProduct>();
        itemProduct.SetInitialize(itemInfo);
        return itemProduct;

    }
}