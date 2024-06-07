using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollToMainPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject player;
    [SerializeField]
    Transform hip;
    Animator animator;
    private void OnEnable()
    {
        StartCoroutine(RespawnPlayer());
        animator = GetComponent<Animator>();
    }
    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(2f);
        player.transform.position = hip.position;
        animator.enabled = true;
        gameObject.SetActive(false);
        player.SetActive(true);

    }
   
}
