using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinionCardDisplayComponent : CardDisplayComponent
{
    [Header("Minion UI Objects")]
    public TextMeshProUGUI MinionHPObject;
    public TextMeshProUGUI MinionAtkObject;

    [Header("Presets")]
    public Sprite CardFrameBasic;
    public Sprite CardFrameUncommon;
    public Sprite CardFrameRare;
    public Sprite CardFrameLegendary;

    public override void SetupCardDisplay(CardData data)
    {
        base.SetupCardDisplay(data);
        MinionHPObject.SetText(((MinionCardData)data).HP.ToString());
        MinionAtkObject.SetText(((MinionCardData)data).Attack.ToString());
        Sprite cardFrame = CardFrameBasic;
        switch (((MinionCardData)data).Rarity)
        {
            case CardRarity.UNCOMMON:
                cardFrame = CardFrameUncommon;
                break;
            case CardRarity.RARE:
                cardFrame = CardFrameRare;
                break;
            case CardRarity.LEGENDARY:
                cardFrame = CardFrameLegendary;
                break;
        }
        CardFrameObject.sprite = cardFrame;
    }

    public MinionCardData GetMinionCardData()
    {
        return (MinionCardData)cardData;
    }
}
