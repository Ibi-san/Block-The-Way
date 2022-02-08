using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    [SerializeField] private LevelSelect _levelSelect;
    [SerializeField] private GameObject _nextLevelButton;
    [SerializeField] private Text _finishtext;
    [SerializeField] private GameObject _specialThanks;

    void Update()
    {
        if (_levelSelect.LevelIndex == _levelSelect._levels.Count - 1)
        {
            _nextLevelButton.SetActive(false);
            _specialThanks.SetActive(true);
            _finishtext.text = "Finish!";
        }
    }
}
