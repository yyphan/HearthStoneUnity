using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalUIManager : MonoBehaviour
{
    public GameObject EndTurnBtn;
    public GameObject EnemyTurnImg;

    public GameObject YourTurnBannerUI;
    public GameObject AlertObject;
    public TextMeshProUGUI AlertTMP;

    public void ToggleEndTurnBtnDisplay(Turn curTurn)
    {
        EndTurnBtn.SetActive(curTurn == Turn.Player);
        EnemyTurnImg.SetActive(curTurn == Turn.Opponent);
    }

    public void ShowYourTurnBanner()
    {
        StartCoroutine(ShowBanner());
    }

    protected IEnumerator ShowBanner()
    {
        YourTurnBannerUI.SetActive(true);

        YourTurnBannerUI.transform.localScale = Vector3.zero;

        for (int i = 0; i < 60; i++)
        {
            YourTurnBannerUI.transform.localScale += new Vector3(0.025f, 0.025f, 0.025f);
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        YourTurnBannerUI.SetActive(false);
    }

    public void ShowAlert(string message)
    {
        StartCoroutine(Alert(message));
    }

    private IEnumerator Alert(string message)
    {
        AlertObject.SetActive(true);
        AlertTMP.SetText(message);

        yield return new WaitForSeconds(1.5f);

        AlertObject.SetActive(false);
    }
}
