using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour
{
    public Transform nextDestination;
    private NavMeshAgent navMeshAgent;
    private Vector3 destination;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        SetDestination();
    }

    void SetDestination()
    {
        if (nextDestination != null)
        {
            destination = nextDestination.transform.position;
            navMeshAgent.SetDestination(destination);
        }

        if (nextDestination == null)
        {
            Debug.Log("Nothing is set as nextDestination.");
        }
    }


}
