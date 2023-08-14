using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Deck : MonoBehaviour
{
    public List<CardData> Candidates;
    public int TotalNumber = 15;
    private Stack<CardData> _deck;

    private void Awake()
    {
        _deck = new Stack<CardData>();
        for (int i = 0; i < TotalNumber; i++)
        {
            int idx = Random.Range(0, Candidates.Count);
            _deck.Push(Candidates[idx]);
        }
    }

    public void Push(CardData newCard)
    {
        _deck.Push(newCard);
    }

    public CardData Pop()
    {
        if (_deck.Count > 0)
            return _deck.Pop();

        return null;
    }
}
