using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    private const string LevelIndexKey = "LevelIndex";
    [SerializeField] private List<GameObject> _levels;

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
}
