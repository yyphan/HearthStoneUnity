using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Turn
{
    Player,
    Opponent
}

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager instance;

    [Header("Turn Management")]
    public GameObject EndTurnBtn;
    public GameObject EnemyTurnImg;
    public HeroController PlayerController;
    public HeroController OpponentController;

    public GameObject YourTurnBannerUI;
    public GameObject AlertObject;
    public TextMeshProUGUI AlertTMP;
    private Turn _curTurn;

    private void Awake()
    {
        if (instance)
            Debug.LogError("GameManager: more than one instance found");
        instance = this;
    }

    private void Start()
    {
        _curTurn = Turn.Opponent;
        EndTurn();
    }

    public void EndTurn()
    {
        _curTurn = _curTurn == Turn.Player ? Turn.Opponent : Turn.Player;
        if (_curTurn == Turn.Player)
        {
            OpponentController.EndTurn();
            PlayerController.StartNewTurn();
            StartCoroutine(ShowYourTurnBanner());
        }
        else
        {
            PlayerController.EndTurn();
            OpponentController.StartNewTurn();
        }
        ToggleEndTurnBtnDisplay();
    }

    private void ToggleEndTurnBtnDisplay()
    {
        EndTurnBtn.SetActive(_curTurn == Turn.Player);
        EnemyTurnImg.SetActive(_curTurn == Turn.Opponent);
    }

    private IEnumerator ShowYourTurnBanner()
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
