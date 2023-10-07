using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public HeroController PlayerController;
    public HeroController OpponentController;
    public GlobalUIManager UIManager;

    private Turn _curTurn;
    public bool IsDraggingLocked { get; set; }

    private void Awake()
    {
        if (instance)
            Debug.LogError("GameManager: more than one instance found");
        instance = this;
    }

    private void Start()
    {
        _curTurn = Turn.Opponent;
        NextTurn();
    }

    public void NextTurn()
    {
        _curTurn = _curTurn == Turn.Player ? Turn.Opponent : Turn.Player;
        if (_curTurn == Turn.Player)
        {
            OpponentController.EndTurn();
            PlayerController.StartNewTurn();
            UIManager.ShowYourTurnBanner();
        }
        else
        {
            PlayerController.EndTurn();
            OpponentController.StartNewTurn();
        }
        UIManager.ToggleEndTurnBtnDisplay(_curTurn);
    }

    public void ShowAlert(string message)
    {
        UIManager.ShowAlert(message);
    }
}
