using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplayComponent : MonoBehaviour
{
    protected CardData cardData;

    [Header("UI Objects")]
    public Image CardImageObject;
    public Image CardFrameObject;
    public TextMeshProUGUI CardNameObject;
    public TextMeshProUGUI CardDescriptionObject;
    public TextMeshProUGUI CardCostObject;


    public virtual void SetupCardDisplay(CardData data)
    {
        CardImageObject.sprite = data.CardImage;
        CardNameObject.SetText(data.CardName);
        CardDescriptionObject.SetText(data.Description);
        CardCostObject.SetText(data.Cost.ToString());
        cardData = data;
    }

    public CardData GetCardData()
    {
        return cardData;
    }
}
