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

    public void PlayCard(CardDisplayComponent card)
    {
        HeroManaController.CostMana(card.GetCardData().Cost);
        HeroHands.RemoveCard(card);
        SummonMinion((MinionCardData)card.GetCardData());
    }

    public bool CanPlayCard(CardDisplayComponent card)
    {
        if (HeroStageManager.IsStageFull())
            return false;

        int cost = card.GetCardData().Cost;
        if (HeroManaController.CanCostMana(cost) == false)
            return false;

        return true;
    }

    protected virtual void SummonMinion(MinionCardData card){ }

    protected void Start()
    {
        HeroImageHolder.sprite = HeroDataObject.HeroSprite;
        healthComponent.Init(HeroDataObject.InitialHP, HeroDataObject.InitialArmor);
    }
}
