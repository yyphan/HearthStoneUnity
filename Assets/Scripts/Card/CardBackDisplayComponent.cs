using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBackDisplayComponent : MinionCardDisplayComponent
{
    public override void SetupCardDisplay(CardData data)
    {
        cardData = data;
        // Do nothing, displaying card back only
    }
}