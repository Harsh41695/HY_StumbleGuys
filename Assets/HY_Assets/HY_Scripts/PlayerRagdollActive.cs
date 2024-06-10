using System.Collections;
using UnityEngine;

public class PlayerRagdollActive : MonoBehaviour
{
    public static PlayerRagdollActive instance;
    Rigidbody[] childRbs;
    Animator animator;

    [SerializeField]
    Transform hip;

    public GameObject Parent;
    //public HY_NavMeshEnemy _refNavMesh;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

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
    public void RagdollActivate()
    {
        animator.enabled = false;
        DisableKinamatic();
        StartCoroutine(ResetRagoll());
    }
    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            animator.enabled = false;
            DisableKinamatic();
            StartCoroutine(ResetRagoll());

        }
    }
}


