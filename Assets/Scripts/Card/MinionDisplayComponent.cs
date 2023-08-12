using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MinionDisplayComponent : MonoBehaviour
{
    private Sprite _minionFrameInActive;
    private Sprite _minionFrameActive;

    [Header("UI Objects")]
    public Image MinionImageObject;
    public Image MinionFrameObject;
    public TextMeshProUGUI MinionHPObject;
    public TextMeshProUGUI MinionAtkObject;

    [Header("Presets")]
    public Sprite MinionFrameBasic;
    public Sprite MinionFrameBasicHighlight;
    public Sprite MinionFrameTaunt;
    public Sprite MinionFrameTauntHighlight;
    public Sprite MinionFrameLegendary;
    public Sprite MinionFrameLegendaryHighlight;
    public Sprite MinionFrameLegendaryTaunt;
    public Sprite MinionFrameLegendaryTauntHighlight;


    public void SetupDisplay(CardData data)
    {
        MinionHPObject.SetText(((MinionCardData)data).HP.ToString());
        MinionAtkObject.SetText(((MinionCardData)data).Attack.ToString());
        MinionImageObject.sprite = data.CardImage;
        switch (((MinionCardData)data).Rarity)
        {
            case CardRarity.LEGENDARY:
                _minionFrameInActive = ((MinionCardData)data).IsTaunt ? MinionFrameLegendaryTaunt : MinionFrameLegendary;
                _minionFrameActive = ((MinionCardData)data).IsTaunt ? MinionFrameLegendaryTauntHighlight : MinionFrameLegendaryHighlight;
                break;
            default:
                _minionFrameInActive = ((MinionCardData)data).IsTaunt ? MinionFrameTaunt : MinionFrameBasic;
                _minionFrameActive = ((MinionCardData)data).IsTaunt ? MinionFrameTauntHighlight : MinionFrameBasicHighlight;
                break;
        }
        SetFrameHighlight(false);
    }

    public void SetFrameHighlight(bool canMove)
    {
        MinionFrameObject.sprite = canMove ? _minionFrameActive : _minionFrameInActive;
    }
}
