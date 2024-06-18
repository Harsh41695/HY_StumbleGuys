using System.Collections;
using UnityEngine;

public class HY_PlayerRagdollActive : MonoBehaviour
{
    public static HY_PlayerRagdollActive instance;
    Rigidbody[] childRbs;
    Animator animator;

    [SerializeField]
    Transform hip;

    public GameObject Parent;
    [SerializeField] GameObject effect;
    Transform spawnPoint;
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
    IEnumerator ResetRagoll(float wait)
    {
        yield return new WaitForSeconds(wait);
        Parent.transform.position = transform.position;
        animator.enabled = true;
        HY_Player_Control.canControl = true;
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
        StartCoroutine(ResetRagoll(3f));
        HY_Player_Control.canControl = false;
    }
    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Obstacle":
                HY_Player_Control.canControl = false;
                animator.enabled = false;
                DisableKinamatic();
                StartCoroutine(ResetRagoll(3f));
                break;
            case "Water":
                Instantiate(effect, transform.position, Quaternion.EulerRotation(90, 0, 0));
                StartCoroutine(ResetRagoll(0.15f));
                break;
        }
        
        
    }
   

}


