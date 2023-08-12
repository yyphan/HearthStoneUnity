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
    [Header("Minion Values")]
    public int Attack;
    public int MaxAttackTimes = 1;
    public int HP;

    public CardRarity Rarity;

    public bool IsTaunt = false;
}
