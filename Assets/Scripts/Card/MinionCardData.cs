using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardRarity
{
    BASIC,
    UNCOMMON,
    RARE,
    LEGENDARY
}

[CreateAssetMenu(fileName = "Minion_Card_Data_New", menuName = "Minion Card Data")]
public class MinionCardData : CardData
{
    public CardRarity Rarity;

    [Header("Minion Values")]
    public int Attack;
    public int MaxAttackTimes = 1;
    public int HP;

    [Header("Minion Keywords")]
    public bool IsTaunt = false;
    public bool IsCharge = false;
}
