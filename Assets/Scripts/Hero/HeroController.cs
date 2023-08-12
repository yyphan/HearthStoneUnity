using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroController : Attackable
{
    [Header("Hero Data")]
    public HeroData HeroDataObject;
    public Image HeroImageHolder;

    public ManaController HeroManaController;
    public Hands HeroHands;

    [Header("Stage")]
    public StageManager HeroStageManager;

    private int _fatigePoints = 0;

    public virtual void StartNewTurn()
    {
        HeroManaController.GrowMana();
        HeroStageManager.StartNewTurn();
        DrawCard();
    }

    public void DrawCard()
    {
        if (!HeroHands.TryDrawCard())
        {
            _fatigePoints++;
            healthComponent.TakeDamage(_fatigePoints, true);
        }
    }

    public bool TryPlayCard(MinionCardDisplayComponent card)
    {
        int cost = card.GetCardData().Cost;
        if (HeroManaController.TryCostMana(cost))
        {
            HeroHands.RemoveCard(card);
            SummonMinion(card.GetMinionCardData());
            return true;
        }
        return false;
    }

    protected virtual void SummonMinion(MinionCardData card){ }

    protected void Start()
    {
        HeroImageHolder.sprite = HeroDataObject.HeroSprite;
        healthComponent.Init(HeroDataObject.InitialHP, HeroDataObject.InitialArmor);
    }
}
