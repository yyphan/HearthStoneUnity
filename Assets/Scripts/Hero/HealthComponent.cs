using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/* Covers both HP and Armor Point*/
public class HealthComponent : MonoBehaviour
{
    public TextMeshProUGUI HPValueTMP;
    public TextMeshProUGUI APValueTMP;
    public GameObject APDisplay;

    private int _currentHP;
    private int _currentAP;

    public void Init(int InitHP, int InitAP = 0)
    {
        _currentHP = InitHP;
        _currentAP = InitAP;
        UpdateUI();
    }

    public void TakeDamage(int amount, bool ignoreArmor = false)
    {
        if (ignoreArmor)
            _currentHP -= amount;
        else
        {
            _currentAP -= amount;
            if (_currentAP < 0)
            {
                _currentHP += _currentAP;
                _currentAP = 0;
            }
        }
        UpdateUI();
    }

    public bool IsDead()
    {
        return _currentHP <= 0;
    }

    private void UpdateUI()
    {
        HPValueTMP.SetText(_currentHP.ToString());
        if (APDisplay != null)
            APDisplay.SetActive(_currentAP > 0);
        if (APValueTMP != null)
            APValueTMP.SetText(_currentAP.ToString());
    }
}
