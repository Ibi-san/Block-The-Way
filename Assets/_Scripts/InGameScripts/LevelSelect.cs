using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    private const string LevelIndexKey = "LevelIndex";
    public List<GameObject> _levels;
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private GameObject _inGameUI;
    [SerializeField] private CameraPivotRotate _cameraPivotRotate;
    [SerializeField] private GameObject _goal;
    [SerializeField] private ParticleSystem _goalCryingParticle;
    [SerializeField] private ParticleSystem _victoryCryingParticle;
    [SerializeField] private ParticleSystem _enemyBrainParticle;
    [SerializeField] private ParticleSystem _enemyZombieLooseParticle;

    public void LoadLevel (int levelIndex)
    {
        LevelIndex = levelIndex;
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
        if (LevelIndex < _levels.Count - 1) LevelIndex++;
        else return;
        _levels[LevelIndex].SetActive(true);
        _winMenu.SetActive(false);
        _inGameUI.SetActive(true);
        _cameraPivotRotate.DefaultPosition();
        _goal.GetComponent<Animator>().SetTrigger("Cry");
        _victoryCryingParticle.Stop();
        _goalCryingParticle.Play();
        _enemyZombieLooseParticle.Stop();
        _enemyBrainParticle.Play();
    }
}
