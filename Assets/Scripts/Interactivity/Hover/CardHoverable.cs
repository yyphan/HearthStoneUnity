using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHoverable : Hoverable
{
    protected override void ShowView()
    {
        base.ShowView();
        CardData cardData = GetComponentInParent<CardDisplayComponent>().GetCardData();
        CardViewManager.instance.ShowCardView(cardData, transform.position.x > Screen.width / 2);
    }

    protected override void HideView()
    {
        base.HideView();
        CardViewManager.instance.HideCardView();
    }
}
