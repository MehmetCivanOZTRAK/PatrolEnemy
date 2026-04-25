using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PatrolEnemy : MonoBehaviour
{
    public Transform[] points;
    private int desPoint = 0;
    private NavMeshAgent agent;
    

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GoToNextPoint();
    }

    private void GoToNextPoint(){
        if(points.Length == 0)
        return;

        agent.destination = points[desPoint].position;
        desPoint = (desPoint + 1) % points.Length;
    }

    private void Update() {
        if(!agent.pathPending && agent.remainingDistance < 0.5f)
        GoToNextPoint();
    }
}

