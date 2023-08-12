using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDropZone : MonoBehaviour, IDropHandler
{
    public float DropZoneOffsetX = 600.0f;
    public float DropZoneOffsetY = 100.0f;

    private void Awake()
    {
        DropZoneOffsetX = ((RectTransform)gameObject.transform).rect.width / 2;
        DropZoneOffsetY = ((RectTransform)gameObject.transform).rect.height / 2;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag && eventData.pointerDrag.GetComponent<MinionCardDraggable>() && !PlayerStageManager.instance.IsStageFull())
        {
            MinionCardDraggable.IsDragValid = true;
        }
    }
}
