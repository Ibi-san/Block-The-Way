using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject _startMenuCanvas;
    [SerializeField] private GameObject _inGameUI;
    [SerializeField] private GameObject _goal;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Text _newGameButtonText;
    [SerializeField] private LevelSelect _levelSelect;

    public const string GameStarted = "gameStarted";

    private void Awake()
    {
        if (gameStarted == true)
        {
            _newGameButtonText.text = "Continue";
        }
        else _newGameButtonText.text = "New Game";
    }

    private void Update()
    {
        
    }

    public void NewGameButton()
    {
        _startMenuCanvas.SetActive(false);
        _levelSelect.LoadLevel(_levelSelect.LevelIndex);
        _inGameUI.SetActive(true);
        _goal.SetActive(true);
        _enemy.SetActive(true);
        PlayerPrefs.SetInt("gameStarted", 1);
        PlayerPrefs.Save();
    }

    public bool gameStarted
    {
        get => PlayerPrefs.GetInt(GameStarted) == 1;
        set
        {
            PlayerPrefs.SetInt(GameStarted, gameStarted ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}
