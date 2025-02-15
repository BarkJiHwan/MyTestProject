using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DragInterface : MonoBehaviour, IBeginDragHandler,IDragHandler , IEndDragHandler
{
    Transform panel;
    GameObject gameObj;
    CanvasGroup canvasGroup;
    Vector3 offset;

    public void OnBeginDrag(PointerEventData eventData)
    {        
        panel = transform.parent;
        Vector3 mousePos = new Vector3(eventData.position.x, eventData.position.y, Camera.main.nearClipPlane);
        offset = transform.position - mousePos;
        transform.SetParent(panel.root);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = new Vector3(eventData.position.x, eventData.position.y, Camera.main.nearClipPlane);
        transform.position = mousePos + offset;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        if (transform.parent == panel.root)
        {
            transform.SetParent(panel);
        }

        HasEnteredPanel();
    }    

    public bool IsDroppedOnUI(PointerEventData eventData)
    {
        return eventData.pointerEnter != null;
    }

    void Start()
    {
        canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    Vector3 HasEnteredPanel()
    {
        //�θ𿴴� �г��� ��� ���� ������Ʈ ��ġ�� ������
        //��, �ΰ��� ȭ���� �Ѿ�� �гξ����� �ٽ� ��ġ�� �̵���ų ����
        RectTransform panelRect = panel.GetComponent<RectTransform>();
        RectTransform objRect = GetComponent<RectTransform>();
        //�� �ǳڰ� ������Ʈ�� RectTransform�� ������ �����´�.

        //GetWorldCorners �Լ��� ���� RectTransform�� �׸𼭸��� ��ǥ�� ������ǥ�� ��ȯ�Ͽ� ����
        //[0] ���� �Ʒ� �𼭸�, [1] ���� �� �𼭸�, [2]������ �� �𼭸�, [3]������ �Ʒ� �𼭸�
        Vector3[] panelCorners = new Vector3[4];
        panelRect.GetWorldCorners(panelCorners);
        
        Vector3[] objCorners = new Vector3[4];
        objRect.GetWorldCorners(objCorners);

        //�� ���̶� �Ѿ�ٸ��� üũ�� bool����
        bool isBeyondBoundary = false;
        //������Ʈ�� ������ ��ġ�� newPosition�� ��Ƶ�
        Vector3 newPosition = transform.position;

        // X�� ����
        //objCorners[0].x + objCorners[3].x�� ���� ���� �� �� �ִ�.
        //�ϴܸ� ���� �Ѿ�ٸ�?
        //��, �ϴܸ��� �������� �̵��߿� �ϴܸ��� �߾��� �ǳ��� 0��° ��ǥ�� �Ѿ�ٸ�
        if ((objCorners[0].x + objCorners[3].x) / 2 < panelCorners[0].x)
        {//newPosition.x�� �ǳ���[0]�� x�� ������Ʈ��rect.width�� �ݸ� ���� ����
         //��, �󸶰� �Ѿ���� ������Ʈ[0]���ο� ������Ʈ�� width���� ���� ���ؼ� �̵� ���Ѷ�.
            newPosition.x = panelCorners[0].x + (objRect.rect.width / 2);
            //��ǥ �̵��� �̷����ٸ� isBeyondBoundary�� true�� �ٲ۴�.
            isBeyondBoundary = true;
        }
        else if ((objCorners[1].x + objCorners[2].x) / 2 > panelCorners[2].x)
        {
            newPosition.x = panelCorners[2].x - (objRect.rect.width / 2);
            isBeyondBoundary = true;
        }

        // Y�� ����        
        if ((objCorners[0].y + objCorners[1].y) / 2 < panelCorners[0].y)
        {
            newPosition.y = panelCorners[0].y + (objRect.rect.height / 2);
            isBeyondBoundary = true;
        }
        else if ((objCorners[2].y + objCorners[3].y) / 2 > panelCorners[1].y)
        {
            newPosition.y = panelCorners[1].y - (objRect.rect.height / 2);
            isBeyondBoundary = true;
        }

        if (isBeyondBoundary)
        {//���� ��ǥ�� �̵��� �̷����ٸ�?
        //x��y�� ���� �ǳ��� ������ �ִ´�.
            if (objCorners[0].x < panelCorners[0].x)
            {
                newPosition.x = panelCorners[0].x + (objRect.rect.width / 2);
            }
            else if (objCorners[2].x > panelCorners[2].x)
            {
                newPosition.x = panelCorners[2].x - (objRect.rect.width / 2);
            }

            // Y �� ����
            if (objCorners[0].y < panelCorners[0].y)
            {
                newPosition.y = panelCorners[0].y + (objRect.rect.height / 2);
            }
            else if (objCorners[1].y > panelCorners[1].y)
            {
                newPosition.y = panelCorners[1].y - (objRect.rect.height / 2);
            }
            transform.position = newPosition;
        }
        return transform.position = newPosition;
    }
}
