using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _goal;
    public NavMeshSurface surface;
    public NavMeshAgent EnemyAgent;
    Vector3 enemyStartPosition;
    [SerializeField] private Game _game;
    [SerializeField] private Enemy _enemy;

    private void Start()
    {
        enemyStartPosition = gameObject.transform.position;
    }

    public void StartNavigation()
    {
        EnemyAgent.enabled = true;
        surface.BuildNavMesh();
        GetComponent<Enemy>().enabled = true;
        EnemyAgent.destination = _goal.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
            _game.levelstarted = false;
            RestartAgent();
            _game.GetComponent<Game>().EnableControl();
    }

    public void RestartAgent()
    {
        GetComponent<Enemy>().enabled = false;
        EnemyAgent.Warp(enemyStartPosition);
        EnemyAgent.enabled = false;
        _enemy.GetComponent<Animator>().SetTrigger("Idle");
    }
}
