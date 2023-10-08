using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MinionOnStageDraggable : Draggable
{
    private Attackable _target;

    public void SetTarget(Attackable target)
    {
        _target = target;
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        if (!gameObject.GetComponent<MinionController>().CanAttack())
        {
            GameManager.instance.ShowAlert("Minion cannot move");
            eventData.pointerDrag = null;
            return;
        }
        base.OnBeginDrag(eventData);
        IsDragValid = false;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        if (_isDragValid)
        {
            OnValidDrag();
        }

        OnInvalidDrag();
    }

    protected override void OnValidDrag()
    {
        base.OnValidDrag();
        ResetPosition();
        GetComponentInParent<MinionController>().Attack(_target);
    }

    protected override void OnInvalidDrag()
    {
        base.OnInvalidDrag();
        ResetPosition();
        PlayerStageManager.instance.ArrangePositionsStatic();
    }
}
