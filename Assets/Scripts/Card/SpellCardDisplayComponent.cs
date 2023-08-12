using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCardDisplayComponent : CardDisplayComponent
{
    private void Start()
    {
        SetupCardDisplay(cardData);
    }
}
