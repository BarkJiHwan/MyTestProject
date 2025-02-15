using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragInterface : MonoBehaviour, IBeginDragHandler,IDragHandler , IEndDragHandler
{
    Transform panel;
    GameObject gameObj;
    CanvasGroup canvasGroup;

    public void OnBeginDrag(PointerEventData eventData)
    {
        panel = transform.parent;

        transform.SetParent(panel.root);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        if (transform.parent == panel.root)
        {
            transform.SetParent (panel);
        }
    }

    public bool IsDroppedOnUI(PointerEventData eventData)
    {
        return eventData.pointerEnter != null;
    }

    void Start()
    {
        canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    void Update()
    {
        
    }
}
