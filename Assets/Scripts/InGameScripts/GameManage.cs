using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManage : MonoBehaviour
{
    [SerializeField] private Transform _goal;
    public NavMeshSurface surface;
    public NavMeshAgent agent;
    [SerializeField] private GameObject _startMenu;
    Vector3 enemyStartPosition;
    bool levelstarted = false;

    private void Start()
    {
        enemyStartPosition = gameObject.transform.position;
    }

    private void Update()
    {
        if (levelstarted == true)
        {
            Invoke("WinCondition", 1.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Loose!");
        RestartLevel();
    }

    public void StartNavigation()
    {
        levelstarted = true;
        agent.enabled = true;
        surface.BuildNavMesh();
        GetComponent<GameManage>().enabled = true;
        agent.destination = _goal.position;
        DisableControl();
    }

    private void RestartLevel()
    {
        levelstarted = false;
        GetComponent<GameManage>().enabled = false;
        agent.Warp(enemyStartPosition);
        agent.enabled = false;
        EnableControl();
    }

    private void DisableControl()
    {
        foreach (GameObject dragObject in GameObject.FindGameObjectsWithTag("MovingObject"))
        {
            dragObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void EnableControl()
    {
        foreach (GameObject dragObject in GameObject.FindGameObjectsWithTag("MovingObject"))
        {
            dragObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private void WinCondition()  //Сделай корутину, которая запускает проверку через секунду после нажатия старта. При рестарте корутина прекращается.
    {
        if (agent.velocity.magnitude == 0)
        {
            Debug.Log("Win!");
            Time.timeScale = 0;
        }
    }

}
