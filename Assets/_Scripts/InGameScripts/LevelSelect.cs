using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    private const string LevelIndexKey = "LevelIndex";
    [SerializeField] private List<GameObject> _levels;
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private GameObject _inGameUI;
    [SerializeField] private CameraPivotRotate _cameraPivotRotate;
    private void Update()
    {

    }

    public void LoadLevel ()
    {
        _levels[LevelIndex].SetActive(true);
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    public void NextLevel()
    {
        _levels[LevelIndex].SetActive(false);
        LevelIndex++;
        _levels[LevelIndex].SetActive(true);
        _winMenu.SetActive(false);
        _inGameUI.SetActive(true);
        _cameraPivotRotate.DefaultPosition();
    }
}
