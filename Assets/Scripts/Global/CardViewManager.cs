using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardViewManager : MonoBehaviour
{
    public static CardViewManager instance;
    public CardDisplayComponent leftView;
    public CardDisplayComponent rightView;

    private void Awake()
    {
        if (instance)
            Debug.LogError("CardViewManager: more than one instance found");
        instance = this;
    }

    public void ShowCardView(CardData cardData, bool showLeft)
    {
        if (showLeft)
        {
            leftView.SetupCardDisplay(cardData);
            leftView.gameObject.SetActive(true);
        }
        else
        {
            rightView.SetupCardDisplay(cardData);
            rightView.gameObject.SetActive(true);
        }
    }

    public void HideCardView()
    {
        leftView.gameObject.SetActive(false);
        rightView.gameObject.SetActive(false);
    }
}
