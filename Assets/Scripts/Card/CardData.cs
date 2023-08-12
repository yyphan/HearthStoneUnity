using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : ScriptableObject
{
    [Header("Displays")]
    public string CardName;
    public string Description;
    public Sprite CardImage;

    [Header("Values")]
    public int Cost;
}
