using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    public Deck Deck;

    public GameObject MinionCardPrefab;
    public float offSet = 100.0f;
    private List<CardDisplayComponent> _cardsInHand = new List<CardDisplayComponent>();
    private const int MAX_CARDS_AT_HAND = 10;

    public bool TryDrawCard()
    {
        CardData data = Deck.Pop();

        if (data == null) // deck empty, enters fatigue
            return false;

        if (_cardsInHand.Count >= MAX_CARDS_AT_HAND) // card is burnt
            return true;

        GameObject CardObject = Instantiate(MinionCardPrefab, transform, false);
        CardDisplayComponent cardDisplay = CardObject.GetComponent<CardDisplayComponent>();
        cardDisplay.SetupCardDisplay(data);
        _cardsInHand.Add(cardDisplay);
        RearrangeHands();
        return true;
    }

    public void RemoveCard(CardDisplayComponent card)
    {
        _cardsInHand.Remove(card);
        RearrangeHands();
    }

    private void RearrangeHands()
    {
        List<float> xOffsets = Utility.CalculateXOffsets(_cardsInHand.Count, offSet);
        // Offset each minion
        for (int index = 0; index < _cardsInHand.Count; index++)
        {
            _cardsInHand[index].transform.position = new Vector3 (transform.position.x + xOffsets[index],
                                                                    transform.position.y,
                                                                    transform.position.z);
        }
    }

    public List<CardDisplayComponent> GetCardsInHand()
    {
        return _cardsInHand;
    }

    public void SetHighlight(bool isActive)
    {
        foreach (CardDisplayComponent card in _cardsInHand)
            card.SetFrameHighlight(isActive);
    }

    public void SetHighlightBasedOnMana(int curMana)
    {
        foreach (CardDisplayComponent card in _cardsInHand)
            card.SetFrameHighlight(card.GetCardData().Cost <= curMana);
    }
}
