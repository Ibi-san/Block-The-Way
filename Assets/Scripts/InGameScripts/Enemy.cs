using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _goal;
    public NavMeshSurface surface;
    public NavMeshAgent agent;
    Vector3 enemyStartPosition;
    [SerializeField] private Game _game;

    private void Start()
    {
        enemyStartPosition = gameObject.transform.position;
    }

    public void StartNavigation()
    {
        agent.enabled = true;
        surface.BuildNavMesh();
        GetComponent<Enemy>().enabled = true;
        agent.destination = _goal.position;
    }

    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("Loose!");
            _game.levelstarted = false;
            RestartAgent();
            _game.GetComponent<Game>().EnableControl();
    }

    public void RestartAgent()
    {
        GetComponent<Enemy>().enabled = false;
        agent.Warp(enemyStartPosition);
        agent.enabled = false;
    }
}
