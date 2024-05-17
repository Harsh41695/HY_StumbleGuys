using UnityEngine;
using UnityEngine.AI;

public class HY_NavMeshEnemy : MonoBehaviour
{
    [SerializeField]
    Transform target, playerTrans;
    [SerializeField]
    NavMeshAgent agent;
    [SerializeField]
    public float rndSpeed = 7.0f, onLinkSpeed = 2;
    HY_Player_Control plc;
    [SerializeField]
    Animator enmyAnim;
    public bool canMove;
    public bool touchedFinishLine;
    [SerializeField]
    float time = 0, changeSpeedFloat = 10;
    public bool followPath;
    //public static bool goRagdoll = false;
    Rigidbody rb;
    void Start()
    {
        //goRagdoll = false;
        rb=GetComponent<Rigidbody>();
        followPath = true;
        agent = GetComponent<NavMeshAgent>();
        plc = GetComponent<HY_Player_Control>();
        enmyAnim = GetComponentInChildren<Animator>();
        if (enmyAnim == null)
        {
            enmyAnim = GetComponent<Animator>();
        }
        canMove = true;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (canMove == true)
        {
            if (time > changeSpeedFloat)
            {
                AISpeedChange();
                time = 0;
            }
            //agent.speed = rndSpeed;

            // setting Destination to the target.
            if (followPath==true)
            {
                agent.SetDestination(target.position);
            }
            enmyAnim.SetFloat("Run", agent.velocity.sqrMagnitude);

            if (agent.isOnOffMeshLink)
            {
                agent.speed = onLinkSpeed;
                enmyAnim.ResetTrigger("Dashing");
                enmyAnim.SetBool("Dash", false);
                enmyAnim.SetBool("Jump", true);
                enmyAnim.SetBool("Hanging", true);
            }
            else
            {
                agent.speed = rndSpeed;
                enmyAnim.SetBool("Jump", false);
                enmyAnim.SetBool("Hanging", false);
            }
            if (Vector3.Distance(transform.position, target.position) <= agent.radius)
            {
                agent.ResetPath();
            }


        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Slider")
        {
            enmyAnim.SetTrigger("Dashing");
            enmyAnim.SetBool("Dash", true);
            agent.speed = rndSpeed * 1.5f;
        }
        if (collision.transform.tag == "Jumper")
        {
            rb.AddForce(Vector3.up * 23f, ForceMode.Impulse);
         
                
        }
        

    }
    void AISpeedChange()
    {
        rndSpeed = Random.Range(3, 9);

    }

    private void OnDrawGizmos()
    {
        if (agent.hasPath)
        {
            for (var i = 0; i < agent.path.corners.Length - 1; i++)
            {
                Debug.DrawLine(agent.path.corners[i], agent.path.corners[i + 1], Color.yellow);
            }
        }
    }

}
