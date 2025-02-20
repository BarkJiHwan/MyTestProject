using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public IItemProduct item; //���Կ� �پ��ִ� �������� ������
    public ItemInfo itemInfo;
    public ItemTooltip itemTooltip;

    private Transform panel;
    public RawImage rawImage;
    RectTransform rectTransform;
    CanvasGroup canvasGroup;
    Vector2 initialPos; //�������� �̵� ������ġ


    private void Start()
    {        
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        rawImage = gameObject.GetComponent<RawImage>();
        panel = transform.parent;
    }
    public void AddItem(ItemInfo newItem)
    {
        itemInfo = newItem;
        rawImage.texture = itemInfo.itemSprite.texture;
        rawImage.enabled = true;
    }
    public void ClearSlot()
    {
        itemInfo = null;
        rawImage.texture = null;
        rawImage.enabled = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {//����ڵ� �������� ���ٸ� ����
        if (item == null)        
            return;
        
        rawImage.color = new Color(rawImage.color.r, rawImage.color.g, rawImage.color.b, 0.6f);
        initialPos = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {//����ڵ� �������� ���ٸ� ����
        if (item == null)
            return;
        //eventData.delta���콺�� �󸶳� ���������� �˷���
        //panel.lossyScale.x; �г��� �������� ����Ͽ� �巡�׸� ����
        //��, �������� 1���� ���� �������� ���� ���
        //�������� ���ڿ� ������ �ʵ��� ����
        rectTransform.anchoredPosition += eventData.delta / panel.lossyScale.x;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //����ڵ� �������� ���ٸ� ����
        if (item == null)
            return;

        rawImage.color = new Color(rawImage.color.r, rawImage.color.g, rawImage.color.b, 1f);

        GameObject dropTarget = eventData.pointerEnter;

        if (dropTarget != null)
        {
            InventorySlot targetSlot = dropTarget.GetComponent<InventorySlot>();
            if (targetSlot != null)
            {
                if (targetSlot.item == null)
                {
                    targetSlot.AddItem(itemInfo);
                    targetSlot.item = item;
                    ClearSlot();
                }
                else
                {
                    ItemInfo tempItemInfo = targetSlot.itemInfo;
                    IItemProduct tempItem = targetSlot.item;

                    targetSlot.AddItem(itemInfo);
                    targetSlot.item = item;

                    AddItem(tempItemInfo);
                    item = tempItem;
                }
            }
            else
            {
                rectTransform.anchoredPosition = initialPos;
            }
        }
        else
        {//RectTransform���ο� �ִ��� Ȯ���ϴ� �޼ҵ�
         //InventoryManager.Instance.DeleteArea������ �ִٸ�
         //��, �κ��丮 ������ �����ٸ� true, �κ��丮 �ȿ��ִٸ� false
            if (RectTransformUtility.RectangleContainsScreenPoint(InventoryManager.Instance.DeleteArea, eventData.position))
            {//�κ��丮 ������ �����ٸ� ��ư Ȱ��ȭ
                panel.parent.GetChild(1).gameObject.SetActive(true);
            }
            else
            {//�ƴϸ� ���� ��ġ�� ���ư�
                rectTransform.anchoredPosition = initialPos;
            }
        }
    }
    
    public void ItemDelete()
    {//��ư�� ���� �޼��带 �����ϱ� ���� ����
        panel.parent.GetChild(1).gameObject.SetActive(false);
        InventoryManager.Instance.RemoveItemFromInventory(this);
        ClearSlot();
        Destroy(gameObject);
    }
    public void ItemDeleteCancel()
    {//��ư�� ���� �޼��带 �����ϱ� ���� ����
        panel.parent.GetChild(1).gameObject.SetActive(false);
        rectTransform.anchoredPosition = initialPos;
    }
}