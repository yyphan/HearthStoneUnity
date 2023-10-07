using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    protected bool _isDragValid = false;
    public bool IsDragValid { set { _isDragValid = value; } }
    private Vector3 _initialPosition;

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        if (GameManager.instance.IsDraggingLocked())
        {
            eventData.pointerDrag = null;
            return;
        }
        _initialPosition = gameObject.transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (GameManager.instance.IsDraggingLocked())
        {
            eventData.pointerDrag = null;
            return;
        }
        gameObject.transform.position = eventData.position;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        if (GameManager.instance.IsDraggingLocked())
        {
            eventData.pointerDrag = null;
            return;
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    protected void ResetPosition()
    {
        gameObject.transform.position = _initialPosition;
    }
}   
