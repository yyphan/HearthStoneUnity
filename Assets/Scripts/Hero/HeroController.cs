using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroController : Attackable, ITurnAware
{
    [Header("Hero Data")]
    public HeroData HeroDataObject;
    public Image HeroImageHolder;

    [Header("Components")]
    public ManaController HeroManaController;
    public Hands HeroHands;
    public StageManager HeroStageManager;

    private int _fatigePoints = 0;

    public virtual void StartNewTurn()
    {
        HeroStageManager.StartNewTurn();
        DrawCard();
        HeroManaController.StartNewTurn();
    }

    public virtual void EndTurn()
    {
        HeroStageManager.EndTurn();
        HeroManaController.EndTurn();
    }

    public void DrawCard()
    {
        if (!HeroHands.TryDrawCard())
        {
            _fatigePoints++;
            healthComponent.TakeDamage(_fatigePoints, true);
        }
    }

    public bool TryPlayCard(CardDisplayComponent card)
    {
        int cost = card.GetCardData().Cost;
        if (HeroManaController.TryCostMana(cost))
        {
            HeroHands.RemoveCard(card);
            SummonMinion((MinionCardData)card.GetCardData());
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
