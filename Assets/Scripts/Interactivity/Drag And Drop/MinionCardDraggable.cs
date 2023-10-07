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
        if (_isDragValid)
        {
            MinionCardDisplayComponent cardDisplay = gameObject.GetComponent<MinionCardDisplayComponent>();
            if (cardDisplay == null)
                Debug.LogError("CardDraggable: CardDisplay not found");
            if (PlayerHeroController.instance.CanPlayCard(cardDisplay))
            {
                PlayerHeroController.instance.PlayCard(cardDisplay);
                Destroy(gameObject);
                return;
            }
        }

        ResetPosition();
        PlayerStageManager.instance.ArrangePositionsStatic();

        CardBeingDragged = null;
    }
}
