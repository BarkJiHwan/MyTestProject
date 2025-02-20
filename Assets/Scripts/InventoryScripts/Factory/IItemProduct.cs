using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemProduct : IProduct
{
    ItemType ItemType { get; }
    ItemInfo ItemInfo { get; }
    void SetPosition(Vector3 pos);
    void UseItem();
}
