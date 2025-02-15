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
        //부모였던 패널의 경계 내로 오브젝트 위치를 제한함
        //즉, 인게임 화면을 넘어가면 패널안으로 다시 위치를 이동시킬 예정
        RectTransform panelRect = panel.GetComponent<RectTransform>();
        RectTransform objRect = GetComponent<RectTransform>();
        //각 판넬과 오브젝트의 RectTransform의 정보를 가져온다.

        //GetWorldCorners 함수를 통해 RectTransform의 네모서리의 좌표를 월드좌표로 변환하여 저장
        //[0] 왼쪽 아래 모서리, [1] 왼쪽 위 모서리, [2]오른쪽 위 모서리, [3]오른쪽 아래 모서리
        Vector3[] panelCorners = new Vector3[4];
        panelRect.GetWorldCorners(panelCorners);
        
        Vector3[] objCorners = new Vector3[4];
        objRect.GetWorldCorners(objCorners);

        //한 면이라도 넘어갔다면을 체크할 bool변수
        bool isBeyondBoundary = false;
        //오브젝트의 기존의 위치를 newPosition에 담아둠
        Vector3 newPosition = transform.position;

        // X축 제한
        //objCorners[0].x + objCorners[3].x를 통해 면을 알 수 있다.
        //하단면 반이 넘어갔다면?
        //즉, 하단면이 왼쪽으로 이동중에 하단면의 중앙이 판넬의 0번째 좌표를 넘어갔다면
        if ((objCorners[0].x + objCorners[3].x) / 2 < panelCorners[0].x)
        {//newPosition.x에 판넬의[0]의 x와 오브젝트의rect.width의 반를 더한 값을
         //즉, 얼마가 넘어갔던지 오브젝트[0]라인에 오브젝트의 width반의 값을 더해서 이동 시켜라.
            newPosition.x = panelCorners[0].x + (objRect.rect.width / 2);
            //좌표 이동이 이뤄졌다면 isBeyondBoundary를 true로 바꾼다.
            isBeyondBoundary = true;
        }
        else if ((objCorners[1].x + objCorners[2].x) / 2 > panelCorners[2].x)
        {
            newPosition.x = panelCorners[2].x - (objRect.rect.width / 2);
            isBeyondBoundary = true;
        }

        // Y축 제한        
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
        {//만약 좌표의 이동이 이뤄졌다면?
        //x와y의 값을 판넬의 안으로 넣는다.
            if (objCorners[0].x < panelCorners[0].x)
            {
                newPosition.x = panelCorners[0].x + (objRect.rect.width / 2);
            }
            else if (objCorners[2].x > panelCorners[2].x)
            {
                newPosition.x = panelCorners[2].x - (objRect.rect.width / 2);
            }

            // Y 축 제한
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
