using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerRagdollActive : MonoBehaviour
{

    Rigidbody[] childRbs;
    Animator animator;
  
    [SerializeField]
    Transform hip;

    public GameObject Parent;
    //public HY_NavMeshEnemy _refNavMesh;
    void Awake()
    {
       
        childRbs = GetComponentsInChildren<Rigidbody>();
        EnableKinamatic();
        animator = GetComponentInParent<Animator>();
       
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

      
        foreach (var child in childRbs)
        {
            child.isKinematic = true;
            child.constraints = RigidbodyConstraints.FreezeAll;
        }


    }
    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            // Debug.Log("Collided to the obstacle");
            animator.enabled = false;
            // followPath = false;
          
            DisableKinamatic();
            StartCoroutine(ResetRagoll());

        }
    }
}


