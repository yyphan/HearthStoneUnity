using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplayComponent : MonoBehaviour
{
    protected CardData cardData;
    public CardData CardData { get { return cardData; } }

    [Header("UI Objects")]
    public Image CardImageObject;
    public Image CardFrameObject;
    public TextMeshProUGUI CardNameObject;
    public TextMeshProUGUI CardDescriptionObject;
    public TextMeshProUGUI CardCostObject;


    public virtual void Init(CardData data)
    {
        cardData = data;
        SetupDisplay();
    }

    protected virtual void SetupDisplay()
    {
        CardImageObject.sprite = cardData.CardImage;
        CardNameObject.SetText(cardData.CardName);
        CardDescriptionObject.SetText(cardData.Description);
        CardCostObject.SetText(cardData.Cost.ToString());
    }

    public virtual void SetFrameHighlight(bool isActive){ }
}
