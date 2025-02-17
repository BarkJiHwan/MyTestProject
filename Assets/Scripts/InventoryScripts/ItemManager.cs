using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public ItemInfo[] allItem;

    public void DropItem(Vector3 Pos, ItemInfo item)
    {
        GameObject itemObj = new GameObject(item.name);
        itemObj.transform.position = Pos;
        
    }
}
