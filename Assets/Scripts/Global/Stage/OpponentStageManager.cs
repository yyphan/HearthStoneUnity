using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentStageManager : StageManager
{
    // Singleton
    public static OpponentStageManager instance;

    private void Awake()
    {
        if (instance)
            Debug.LogError("OpponentStageManager: more than one instance found");
        instance = this;
    }
}
