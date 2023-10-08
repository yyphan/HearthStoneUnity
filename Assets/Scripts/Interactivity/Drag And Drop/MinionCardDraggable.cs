using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MinionCardDraggable : Draggable
{
    public static MinionCardDisplayComponent CardBeingDragged = null;

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        CardBeingDragged = gameObject.GetComponent<MinionCardDisplayComponent>();
        IsDragValid = false;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        if (_isDragValid && CardBeingDragged && PlayerHeroController.instance.CanPlayCard(CardBeingDragged))
        {
            OnValidDrag();
        }

        OnInvalidDrag();
    }

    protected override void OnInvalidDrag()
    {
        base.OnInvalidDrag();
        ResetPosition();
        PlayerStageManager.instance.ArrangePositionsStatic();

        CardBeingDragged = null;
    }

    protected override void OnValidDrag()
    {
        base.OnValidDrag();
        PlayerHeroController.instance.PlayCard(CardBeingDragged);
        Destroy(gameObject);

        CardBeingDragged = null;
    }
}
