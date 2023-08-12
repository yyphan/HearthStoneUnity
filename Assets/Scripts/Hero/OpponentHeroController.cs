using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpponentHeroController : HeroController
{
    // Singleton
    public static OpponentHeroController instance;

    public GameObject TauntObject;
    public TextMeshProUGUI TauntText;

    private List<string> _tauntMessages = new List<string>() { 
        "Wait Till I Have Enough Mana!", 
        "I Will CRUSH You!",
        "...Where Are My Minions?",
        "Stop CHEATING!"
    };

    protected override void Awake()
    {
        base.Awake();
        if (instance)
            Debug.LogError("OpponentHeroController: more than one instance found");
        instance = this;
    }

    public override void StartNewTurn()
    {
        base.StartNewTurn();

        StartCoroutine(PretendToThink());
    }

    protected override void SummonMinion(MinionCardData card)
    {
        base.SummonMinion(card);
        OpponentStageManager.instance.SummonMinion(card);
    }

    private IEnumerator PretendToThink()
    {
        yield return new WaitForSeconds(0.8f);

        CardDisplayComponent leftMostCard = (CardDisplayComponent) HeroHands.GetCardsInHand()[0];
        TryPlayCard(leftMostCard);

        int tauntCount = Random.Range(-_tauntMessages.Count, _tauntMessages.Count);
        if (tauntCount > 0) 
            StartCoroutine(Taunt(_tauntMessages[tauntCount]));

        yield return new WaitForSeconds(1.5f);

        GameManager.instance.EndTurn();
    }

    private IEnumerator Taunt(string message)
    {
        TauntText.SetText(message);
        TauntObject.SetActive(true);

        yield return new WaitForSeconds(2.5f);

        TauntObject.SetActive(false);
    }
}   
