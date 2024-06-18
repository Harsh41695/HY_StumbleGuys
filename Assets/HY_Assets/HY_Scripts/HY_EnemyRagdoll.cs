using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class HY_EnemyRagdoll : MonoBehaviour
{
   
    Rigidbody[] childRbs;
    Animator animator;
    private NavMeshAgent agent_Ref;
    [SerializeField]
    Transform hip;
    
    public GameObject Parent;
    public HY_NavMeshEnemy _refNavMesh;
    void Awake()
    {
       
        _refNavMesh = GetComponentInParent<HY_NavMeshEnemy>();
        childRbs = GetComponentsInChildren<Rigidbody>();
        EnableKinamatic();
        animator = GetComponentInParent<Animator>();
        agent_Ref = GetComponentInParent<NavMeshAgent>();
    }

   
  
    void EnableKinamatic()
    {
        foreach (var child in childRbs)
        {
            child.isKinematic = true;
            child.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    void DisableKinamatic()
    {
        foreach (var child in childRbs)
        {
            child.isKinematic = false;
            child.constraints = RigidbodyConstraints.None;
        }
    }
    IEnumerator ResetRagoll()
    {
        yield return new WaitForSeconds(3f);
       // HY_NavMeshEnemy.goRagdoll = false;
        Parent.transform.position = transform.position;
        animator.enabled = true;
        
        _refNavMesh.followPath = true;
        foreach (var child in childRbs)
        {
            child.isKinematic = true;
            child.constraints = RigidbodyConstraints.FreezeAll;
        }


    }
    //  Must Use Event here........
    public void EnemyRagdoll()
    {
        // Debug.Log("Collided to the obstacle");
        animator.enabled = false;
        agent_Ref.speed = 0;
        agent_Ref.ResetPath();
        // followPath = false;
        _refNavMesh.followPath = false;
        DisableKinamatic();
        StartCoroutine(ResetRagoll());
    }
    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Obstacle" && _refNavMesh!=null)
        {
           // Debug.Log("Collided to the obstacle");
            animator.enabled = false;
            agent_Ref.speed = 0;
            agent_Ref.ResetPath();
           // followPath = false;
           _refNavMesh.followPath=false;
            DisableKinamatic();
            StartCoroutine(ResetRagoll());
            if (_refNavMesh == null)
            {
                animator.enabled = false;
                DisableKinamatic();
                StartCoroutine(ResetRagoll());
            }

        }
    }
}
