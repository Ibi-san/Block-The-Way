using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentGoal : MonoBehaviour
{
    [SerializeField] private Transform _goal;
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = _goal.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
        Debug.Log("Loose!");
    }
}
