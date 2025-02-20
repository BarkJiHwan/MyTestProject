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
            Debug.LogError("ItemPrefab �Ǵ� Ÿ�� ������Ʈ�� �������� �ʾҽ��ϴ�.");
            return null;
        }

        GameObject itemObject = GameObject.Instantiate(_itemPrefab, target.transform.position, Quaternion.identity);
        IItemProduct item = itemObject.GetComponent<IItemProduct>();

        if (item == null)
        {
            Debug.LogError("�����տ� IItemProduct ������Ʈ�� �����ϴ�.");
            return null;
        }

        item.SetPosition(target.transform.position);
        return item;
    }
}
