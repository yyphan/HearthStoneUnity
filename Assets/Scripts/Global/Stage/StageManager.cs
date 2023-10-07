using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour, ITurnAware
{
    public List<MinionController> MinionsOnStage;
    public GameObject MinionPrefab;

    [Header("Display Configs")]
    public float offSet = 150.0f;

    protected int newMinionIndex;

    private const int MOS_CAP = 7;

    public void SpawnMinion(MinionCardData data)
    {
        GameObject newMinion = Instantiate(MinionPrefab, transform);
        MinionController minionController = newMinion.GetComponent<MinionController>();
        MinionsOnStage.Insert(newMinionIndex, minionController);
        minionController.Initialize(data);
        ArrangePositionsStatic();
    }

    public bool TryRemoveMinion(MinionController minion)
    {
        if (MinionsOnStage.Remove(minion))
        {
            ArrangePositionsStatic();
            return true;
        }

        return false;
    }

    // Arranges minions on stage
    public void ArrangePositionsStatic()
    {
        int minionsCount = MinionsOnStage.Count;
        List<float> xOffsets = Utility.CalculateXOffsets(minionsCount, offSet);
        // Offset each minion
        for (int index = 0; index < minionsCount; index++)
            MinionsOnStage[index].SetLocalPosX(xOffsets[index]);
    }

    public bool IsStageFull()
    {
        return MinionsOnStage.Count >= MOS_CAP;
    }

    public bool AreThereTaunts()
    {
        foreach (MinionController minion in MinionsOnStage)
        {
            if (minion.IsTaunt())
                return true;
        }

        return false;
    }

    public void StartNewTurn()
    {
        foreach (MinionController minion in MinionsOnStage)
            minion.StartNewTurn();
    }

    public void EndTurn() 
    {
        foreach (MinionController minion in MinionsOnStage)
            minion.EndTurn();
    }
}
