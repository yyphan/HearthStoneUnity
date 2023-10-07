using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeroController : HeroController
{ 
    // Singleton
    public static PlayerHeroController instance;

    protected override void Awake()
    {
        base.Awake();
        if (instance)
            Debug.LogError("PlayerHeroController: more than one instance found");
        instance = this;
    }

    public void UpdatePlayableCards(int curMana)
    {
        HeroHands.SetHighlightBasedOnMana(curMana);
    }

    protected override void SummonMinion(MinionCardData card)
    {
        base.SummonMinion(card);
        PlayerStageManager.instance.SpawnMinion(card);
    }
}
