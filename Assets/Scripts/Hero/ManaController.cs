using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManaController : MonoBehaviour
{
    public TextMeshProUGUI UIText;
    public List<GameObject> UIGems;
    public bool DisplayUI = true;

    private int _curMana = 0;
    private int _availMana = 0;
    private const int MAX_MANA = 10;
    private const string MANA_TEXT_TEMPLATE = "{0}/{1}";

    public void GrowMana()
    {
        _availMana = Mathf.Min(MAX_MANA, _availMana + 1);
        _curMana = _availMana;
        UpdateUI();
    }

    public bool TryCostMana(int cost)
    {
        if (_curMana < cost)
        {
            return false;
        }
        _curMana -= cost;
        UpdateUI();
        return true;
    }

    public void ReplenishMana(int amount)
    {
        _curMana = Mathf.Max(_availMana, _curMana + amount);
        UpdateUI();
    }

    private void UpdateUI()
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
