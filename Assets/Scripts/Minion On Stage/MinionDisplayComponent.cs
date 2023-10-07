using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MinionDisplayComponent : MonoBehaviour
{
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

    protected MinionCardData cardData;
    public MinionCardData CardData { get { return cardData; }  }

    private Sprite _minionFrameInActive;
    private Sprite _minionFrameActive;

    public void Init(MinionCardData data)
    {
        cardData = data;
        SetupDisplay();
        SetFrameHighlight(false);
    }

    private void SetupDisplay()
    {
        MinionHPObject.SetText(cardData.HP.ToString());
        MinionAtkObject.SetText(cardData.Attack.ToString());
        MinionImageObject.sprite = cardData.CardImage;
    }

    private void AssignFrameAssets()
    {
        switch (cardData.Rarity)
        {
            case CardRarity.LEGENDARY:
                _minionFrameInActive = cardData.IsTaunt ? MinionFrameLegendaryTaunt : MinionFrameLegendary;
                _minionFrameActive = cardData.IsTaunt ? MinionFrameLegendaryTauntHighlight : MinionFrameLegendaryHighlight;
                break;
            default:
                _minionFrameInActive = cardData.IsTaunt ? MinionFrameTaunt : MinionFrameBasic;
                _minionFrameActive = cardData.IsTaunt ? MinionFrameTauntHighlight : MinionFrameBasicHighlight;
                break;
        }
    }

    public void SetFrameHighlight(bool canMove)
    {
        if (!_minionFrameActive || !_minionFrameInActive)
        {
            AssignFrameAssets();
        }
        MinionFrameObject.sprite = canMove ? _minionFrameActive : _minionFrameInActive;
    }
}
