using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemybehavior : MonoBehaviour
{
    public Transform patrolroute;
    public List<Transform> locations;

    private int LocationIndex = 0;
    private NavMeshAgent agent;

    void Start()
    {
        agent= GetComponent<NavMeshAgent>();

        initalizepatrolroute();

        movetonextpatrollocation();
    }

    void initalizepatrolroute()
    {
        foreach(Transform child in patrolroute)
        {
            locations.Add(child);
        }
    }
        
    void movetonextpatrollocation()
    {
        if (locations.Count == 0)
            return;
        
        agent.destination = locations[LocationIndex].position;

        LocationIndex = (LocationIndex + 1) % locations.Count;
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "player")
        {
            Debug.Log("player detected - ATTACK!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "player")
        {
            Debug.Log("player out of range - Resume Patrol");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.3f && !agent.pathPending)
        {
            movetonextpatrollocation();
        }
    }
}
