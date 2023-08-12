using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinionCardDisplayComponent : CardDisplayComponent
{
    private Sprite _cardFrameInActive;
    private Sprite _cardFrameActive;

    [Header("Minion UI Objects")]
    public TextMeshProUGUI MinionHPObject;
    public TextMeshProUGUI MinionAtkObject;

    [Header("Presets")]
    public Sprite CardFrameBasic;
    public Sprite CardFrameUncommon;
    public Sprite CardFrameRare;
    public Sprite CardFrameLegendary;
    public Sprite CardFrameBasic_Highlight;
    public Sprite CardFrameUncommon_Highlight;
    public Sprite CardFrameRare_Highlight;
    public Sprite CardFrameLegendary_Highlight;

    public override void SetupCardDisplay(CardData data)
    {
        base.SetupCardDisplay(data);
        MinionHPObject.SetText(((MinionCardData)data).HP.ToString());
        MinionAtkObject.SetText(((MinionCardData)data).Attack.ToString());
        switch (((MinionCardData)data).Rarity)
        {
            case CardRarity.BASIC:
                _cardFrameInActive = CardFrameBasic;
                _cardFrameActive = CardFrameBasic_Highlight;
                break;
            case CardRarity.UNCOMMON:
                _cardFrameInActive = CardFrameUncommon;
                _cardFrameActive = CardFrameUncommon_Highlight;
                break;
            case CardRarity.RARE:
                _cardFrameInActive = CardFrameRare;
                _cardFrameActive = CardFrameRare_Highlight;
                break;
            case CardRarity.LEGENDARY:
                _cardFrameInActive = CardFrameLegendary;
                _cardFrameActive = CardFrameLegendary_Highlight;
                break;
        }
        SetFrameHighlight(false);
    }

    public override void SetFrameHighlight(bool isActive)
    {
        base.SetFrameHighlight(isActive);
        CardFrameObject.sprite = isActive ? _cardFrameActive : _cardFrameInActive;
    }
}
