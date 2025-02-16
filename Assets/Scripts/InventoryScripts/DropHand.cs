using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropHand : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.SetParent(transform);
        }
    }

    void Start()
    {
        if(EventSystem.current.alreadySelecting)
        {

        }
        GameObject selected = EventSystem.current.currentSelectedGameObject;
        if (selected != null)
        {

        }
        if(EventSystem.current.IsPointerOverGameObject())
        {

        }
        EventSystem.current.sendNavigationEvents = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
