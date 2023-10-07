using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBackDisplayComponent : CardDisplayComponent
{
    public override void Init(CardData data)
    {
        cardData = data;
        // Do nothing, displaying card back only
    }
}
