using UnityEngine;
using UnityEngine.AI;

public class HY_RandomPathMovement : MonoBehaviour
{
    public float changeDestinationInterval = 5f; // Interval to change destination
    public float maxPathDistance = 20f; // Maximum distance of the path
    private NavMeshAgent agent;
    private Vector3 targetPosition;
    private float lastDestinationChangeTime;
    [SerializeField]
    Transform spawnPoint;
    [SerializeField]
    Transform target;
    float z;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }

    void Update()
    {
        // Check if it's time to change the destination
        if (Time.time - lastDestinationChangeTime > changeDestinationInterval)
        {
            SetRandomDestination();
        }

        // Check if the agent has reached its destination
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            SetRandomDestination();
        }
        NavMeshPath path = GetComponent<NavMeshPath>();
        
    }

    void SetRandomDestination()
    {
        // Generate a random point within maxPathDistance
        Vector3 randomDirection = Random.insideUnitSphere * maxPathDistance;
         z+= 10;

        randomDirection += transform.forward;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, maxPathDistance, NavMesh.AllAreas);
        targetPosition = hit.position;

                // Set the agent's destination to the random point
        agent.SetDestination(targetPosition);
        lastDestinationChangeTime = Time.time;
    }
   
}
