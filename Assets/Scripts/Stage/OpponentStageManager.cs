using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentStageManager : StageManager
{
    // Singleton
    public static OpponentStageManager instance;

    public bool TryRemoveMinion(MinionController minion)
    {
        if (MinionsOnStage.Remove(minion))
        {
            ArrangePositionsStatic();
            return true;
        }

        return false;
    }

    private void Awake()
    {
        if (instance)
            Debug.LogError("OpponentStageManager: more than one instance found");
        instance = this;
    }
}
