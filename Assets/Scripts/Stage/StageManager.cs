using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public List<MinionController> MinionsOnStage;
    public GameObject MinionPrefab;
    public List<MinionCardData> ToSpawn;

    [Header("Display Configs")]
    public float offSet = 150.0f;

    protected int newMinionIndex;

    private const int MOS_CAP = 7;

    public void SummonMinion(MinionCardData data)
    {
        GameObject newMinion = Instantiate(MinionPrefab, transform);
        MinionController minionController = newMinion.GetComponent<MinionController>();
        MinionsOnStage.Insert(newMinionIndex, minionController);
        minionController.Initialize(data);
        ArrangePositionsStatic();
    }

    // Arranges minions on stage
    public void ArrangePositionsStatic()
    {
        int minionsCount = MinionsOnStage.Count;
        List<float> xOffsets = Utility.CalculateXOffsets(minionsCount, offSet);
        // Offset each minion
        for (int index = 0; index < minionsCount; index++)
        {
            MinionsOnStage[index].SetLocalPosX(xOffsets[index]);
        }
    }

    public void StartNewTurn()
    {
        foreach (MinionController minion in MinionsOnStage)
        {
            minion.RecoverAttackTimes();
            minion.UpdateFrameHighlight();
        }
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

    // Debug only
    private void Start()
    {
        foreach (MinionCardData data in ToSpawn)
        {
            SummonMinion(data);
        }
    }
}
