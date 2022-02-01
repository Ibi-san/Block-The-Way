using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Transform _goal;
    public NavMeshSurface surface;
    public NavMeshAgent agent;
    [SerializeField] private GameObject _startMenu;
    Vector3 enemyStartPosition;

    [SerializeField] private DragObject[] dragObjects;

    void Start()
    {
        enemyStartPosition = gameObject.transform.position;

        GameObject[] _dragObjects = GameObject.FindGameObjectsWithTag("MovingObject");
        dragObjects = new DragObject[_dragObjects.Length];
        for (int i = 0; i < dragObjects.Length; ++i)
            dragObjects[i] = _dragObjects[i].GetComponent<DragObject>();
    }

    private void Update()
    {
        //Debug.Log(agent.velocity.magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Loose!");
        RestartLevel();
    }

    public void StartNavigation()
    {
        agent.enabled = true;
        surface.BuildNavMesh();
        GetComponent<Game>().enabled = true;
        agent.destination = _goal.position;
        DisableControl();
    }

    private void RestartLevel()
    {
        GetComponent<Game>().enabled = false;
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

}
