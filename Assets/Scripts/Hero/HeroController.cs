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
        HeroStageManager.StartNewTurn();
        DrawCard();
        HeroHands.SetHighlight(true);
        HeroManaController.GrowMana();
    }

    public virtual void EndTurn()
    {
        HeroHands.SetHighlight(false);
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
