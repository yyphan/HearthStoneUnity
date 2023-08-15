using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManaController : MonoBehaviour, ITurnAware
{
    public TextMeshProUGUI UIText;
    public List<GameObject> UIGems;
    public bool DisplayUI = true;

    private int _curMana = 0;
    private int _availMana = 0;
    private const int MAX_MANA = 10;
    private const string MANA_TEXT_TEMPLATE = "{0}/{1}";

    public void StartNewTurn()
    {
        GrowMana();
    }

    public void EndTurn()
    {
        SetCurMana(0);
    }

    public void CostMana(int cost)
    {
        SetCurMana(_curMana - cost);
    }

    public bool CanCostMana(int cost)
    {
        return _curMana >= cost;
    }

    protected void SetCurMana(int value)
    {
        _curMana = value;
        UpdateUI();
    }

    protected void GrowMana()
    {
        _availMana = Mathf.Min(MAX_MANA, _availMana + 1);
        SetCurMana(_availMana);
    }

    protected void UpdateUI()
    {
        if (!DisplayUI)
            return;
        UIText.SetText(MANA_TEXT_TEMPLATE, _curMana, _availMana);
        for (int i = 0; i < MAX_MANA; i++)
        {
            UIGems[i].SetActive(i < _curMana);
        }

        // Update playable cards
        PlayerHeroController.instance.UpdatePlayableCards(_curMana);
    }
}
