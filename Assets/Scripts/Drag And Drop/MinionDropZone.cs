using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MinionDropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag && eventData.pointerDrag.GetComponent<MinionOnStageDraggable>())
        {
            MinionOnStageDraggable minionDraggable = eventData.pointerDrag.GetComponent<MinionOnStageDraggable>();
            // YOU MUST ATTACK THAT MINION WITH TAUNT
            if (OpponentStageManager.instance.AreThereTaunts() && !IsThisTaunt())
            {
                minionDraggable.SetIsDragValid(false);
                GameManager.instance.ShowAlert("YOU MUST ATTACK THAT MINION WITH TAUNT");
            }
            else
            {
                minionDraggable.SetIsDragValid(true);
                minionDraggable.SetTarget(GetComponentInParent<Attackable>());
            }
        }
    }

    private bool IsThisTaunt()
    {
        // Could be hero
        if (gameObject.GetComponentInParent<HeroController>() != null)
            return false;

        return gameObject.GetComponentInParent<MinionController>().IsTaunt();
    }
}
