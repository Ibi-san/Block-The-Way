using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Game : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Collider _goalCollider;
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private GameObject _inGameUI;
    [SerializeField] private LevelSelect _levelSelect;
    public bool levelstarted = false;
    public Enemy _enemy;

    

    private void Update()
    {
        if (levelstarted == false)
            StopCoroutine("WinCondition");

        if (levelstarted == true)
            StartCoroutine("WinCondition");
    }

    public void PlayLevel()
    {
        levelstarted = true;
        _enemy.GetComponent<Enemy>().StartNavigation();
        DisableControl();
    }

    private void DisableControl()
    {
        foreach (GameObject dragObject in GameObject.FindGameObjectsWithTag("MovingObject"))
        {
            dragObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public void EnableControl()
    {
        foreach (GameObject dragObject in GameObject.FindGameObjectsWithTag("MovingObject"))
        {
            dragObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }


    IEnumerator WinCondition()
    {
        yield return new WaitForSeconds(1);
        if (agent.velocity.magnitude == 0)
        {
            _winMenu.SetActive(true);
            _inGameUI.SetActive(false);
            levelstarted = false;
            EnableControl();
            _enemy.RestartAgent();
        }
    }

}
