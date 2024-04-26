using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class AIPathfinding : MonoBehaviour
{
    public Transform destination;
    public float amplitude = 1f; // Adjust this value to control the zig-zag intensity

    private NavMeshAgent agent;
    private List<Vector3> path;
    private int currentWaypoint = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // Calculate the zig-zag path from current position to the destination
        path = CalculateZigZagPath(transform.position, destination.position);
        // Set the calculated path for the NavMeshAgent
        agent.SetPath(CreateNavMeshPath(path));
    }

    void Update()
    {
        // Check if the agent has reached the current waypoint
        if (agent.remainingDistance < agent.stoppingDistance)
        {
            currentWaypoint++;
            // Check if the agent reached the end of the path
            if (currentWaypoint >= path.Count)
            {
                // Stop the agent
                agent.isStopped = true;
            }
            else
            {
                // Set the next waypoint for the agent
                agent.SetDestination(path[currentWaypoint]);
            }
        }
    }

    List<Vector3> CalculateZigZagPath(Vector3 startPos, Vector3 targetPos)
    {
        List<Vector3> newPath = new List<Vector3>();
        newPath.Add(startPos);

        // Calculate the zig-zag pattern
        Vector3 direction = (targetPos - startPos).normalized;
        float distance = Vector3.Distance(startPos, targetPos);
        float halfDistance = distance / 2f;

        for (float i = 0; i < halfDistance; i += 1f)
        {
            Vector3 offset = direction * i;
            Vector3 point1 = startPos + offset + Vector3.up * amplitude;
            Vector3 point2 = startPos + offset + Vector3.down * amplitude;
            newPath.Add(point1);
            newPath.Add(point2);
        }

        newPath.Add(targetPos);
        return newPath;
    }

    NavMeshPath CreateNavMeshPath(List<Vector3> waypoints)
    {
        NavMeshPath navMeshPath = new NavMeshPath();
        for (int i = 0; i < waypoints.Count; i++)
        {
            NavMesh.CalculatePath(i == 0 ? transform.position : waypoints[i - 1], waypoints[i], NavMesh.AllAreas, navMeshPath);
        }
        return navMeshPath;
    }
}
