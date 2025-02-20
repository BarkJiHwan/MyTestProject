using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProductFactory
{
    private readonly GameObject _itemPrefab;

    public ItemProductFactory(GameObject itemPrefab)
    {
        _itemPrefab = itemPrefab;
    }
    public IItemProduct CreateProduct(GameObject target)
    {
        if (_itemPrefab == null || target == null)
        {
            Debug.LogError("ItemPrefab 또는 타겟 오브젝트가 설정되지 않았습니다.");
            return null;
        }

        GameObject itemObject = GameObject.Instantiate(_itemPrefab, target.transform.position, Quaternion.identity);
        IItemProduct item = itemObject.GetComponent<IItemProduct>();

        if (item == null)
        {
            Debug.LogError("프리팹에 IItemProduct 컴포넌트가 없습니다.");
            return null;
        }

        item.SetPosition(target.transform.position);
        return item;
    }
}
