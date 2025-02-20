using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public IItemProduct item; //슬롯에 붙어있는 아이템을 참조함
    public ItemInfo itemInfo;
    public ItemTooltip itemTooltip;

    private Transform panel;
    public RawImage rawImage;
    RectTransform rectTransform;
    CanvasGroup canvasGroup;
    Vector2 initialPos; //아이템의 이동 시작위치


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
    {//방어코드 아이템이 없다면 리턴
        if (item == null)        
            return;
        
        rawImage.color = new Color(rawImage.color.r, rawImage.color.g, rawImage.color.b, 0.6f);
        initialPos = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {//방어코드 아이템이 없다면 리턴
        if (item == null)
            return;
        //eventData.delta마우스가 얼마나 움직였는지 알려줌
        //panel.lossyScale.x; 패널의 스케일을 고려하여 드래그를 조정
        //즉, 스케일이 1보다 작은 아이템이 있을 경우
        //아이템이 부자연 스럽지 않도록 조정
        rectTransform.anchoredPosition += eventData.delta / panel.lossyScale.x;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //방어코드 아이템이 없다면 리턴
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
        {//RectTransform내부에 있는지 확인하는 메소드
         //InventoryManager.Instance.DeleteArea영역에 있다면
         //즉, 인벤토리 밖으로 나갔다면 true, 인벤토리 안에있다면 false
            if (RectTransformUtility.RectangleContainsScreenPoint(InventoryManager.Instance.DeleteArea, eventData.position))
            {//인벤토리 밖으로 나갔다면 버튼 활성화
                panel.parent.GetChild(1).gameObject.SetActive(true);
            }
            else
            {//아니면 시작 위치로 돌아감
                rectTransform.anchoredPosition = initialPos;
            }
        }
    }
    
    public void ItemDelete()
    {//버튼을 통해 메서드를 실행하기 위해 구현
        panel.parent.GetChild(1).gameObject.SetActive(false);
        InventoryManager.Instance.RemoveItemFromInventory(this);
        ClearSlot();
        Destroy(gameObject);
    }
    public void ItemDeleteCancel()
    {//버튼을 통해 메서드를 실행하기 위해 구현
        panel.parent.GetChild(1).gameObject.SetActive(false);
        rectTransform.anchoredPosition = initialPos;
    }
}