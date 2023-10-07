using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStageManager : StageManager
{
    // Singleton
    public static PlayerStageManager instance;
    protected CardDropZone _cardDropZone;

    private void Awake()
    {
        if (instance)
            Debug.LogError("PlayerStageManager: more than one instance found");
        instance = this; 
        
        _cardDropZone = GetComponentInChildren<CardDropZone>();
        if (!_cardDropZone)
            Debug.LogError("PlayerStageManager: expected CardDropZone in children but not found");
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldRespondToDraggingMinion())
            ArrangePositionDynamic(Input.mousePosition.x);
    }

    // Arranges minions on stage as player tries to put on another minion
    private void ArrangePositionDynamic(float mouseX)
    {
        if (instance.IsStageFull())
            return;

        int potentialMinionsCount = MinionsOnStage.Count + 1;
        List<float> xOffsets = Utility.CalculateXOffsets(potentialMinionsCount, offSet);

        newMinionIndex = 0;
        for (int index = 0; index < MinionsOnStage.Count; index++)
        {
            if (MinionsOnStage[index].transform.position.x < mouseX)
            {
                MinionsOnStage[index].SetLocalPosX(_cardDropZone.transform.localPosition.x + xOffsets[index]);
                newMinionIndex++;
            }
            else
            {
                MinionsOnStage[index].SetLocalPosX(_cardDropZone.transform.localPosition.x + xOffsets[index + 1]);
            }
        }
    }

    private bool IsMouseWithinDropZone()
    {
        return Mathf.Abs(Input.mousePosition.x - _cardDropZone.transform.position.x) < _cardDropZone.DropZoneOffsetX
            && Mathf.Abs(Input.mousePosition.y - _cardDropZone.transform.position.y) < _cardDropZone.DropZoneOffsetY;
    }

    private bool ShouldRespondToDraggingMinion()
    {
        if (GameManager.instance.IsDraggingLocked())
            return false;

        if (IsMouseWithinDropZone() == false)
            return false;

        if (MinionCardDraggable.CardBeingDragged == null)
            return false;

        if (!PlayerHeroController.instance.CanPlayCard(MinionCardDraggable.CardBeingDragged))
            return false;

        return true;
    }
}
