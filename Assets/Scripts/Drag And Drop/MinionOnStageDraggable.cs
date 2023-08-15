using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MinionOnStageDraggable : Draggable
{
    private bool _isDragValid = false;
    private Attackable _target;

    public void SetDragValid(Attackable target)
    {
        _isDragValid = true;
        _target = target;
    }

    public void SetDragInvalid()
    {
        _isDragValid = false;
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        if (!gameObject.GetComponent<MinionController>().CanAttack())
        {
            GameManager.instance.ShowAlert("Minion cannot move any more");
            eventData.pointerDrag = null;
            return;
        }
        base.OnBeginDrag(eventData);
        SetDragInvalid();
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        ResetPosition();
        if (_isDragValid)
        {
            GetComponentInParent<MinionController>().Attack(_target);
        }
        else
        {
            PlayerStageManager.instance.ArrangePositionsStatic();
        }
    }
}
