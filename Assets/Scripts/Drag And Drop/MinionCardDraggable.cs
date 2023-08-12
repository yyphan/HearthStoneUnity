using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MinionCardDraggable : Draggable
{
    public static bool IsDragValid = false;
    public static bool IsDragging = false;

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        IsDragging = true;
        IsDragValid = false;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        IsDragging = false;
        if (IsDragValid)
        {
            MinionCardDisplayComponent cardDisplay = gameObject.GetComponent<MinionCardDisplayComponent>();
            if (!cardDisplay)
                Debug.LogError("CardDraggable: CardDisplay not found");
            if (PlayerHeroController.instance.TryPlayCard(cardDisplay))
            {
                Destroy(gameObject);
            }
            else
            {
                ResetPosition();
                PlayerStageManager.instance.ArrangePositionsStatic();
            }
        }
        else
        {
            ResetPosition();
            PlayerStageManager.instance.ArrangePositionsStatic();
        }
    }
}
