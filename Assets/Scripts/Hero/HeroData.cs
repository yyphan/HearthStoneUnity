using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hero_Data_New", menuName = "Hero Data")]
public class HeroData : ScriptableObject
{
    public Sprite HeroSprite;
    public string HeroName;

    public int InitialHP = 0;
    public int InitialArmor = 0;
}
