using UnityEngine;

public class MainPlayerToRagdoll : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject ragDollPlayer;
    [SerializeField]
    Transform hip;
    
    private void Awake()
    {
        ragDollPlayer.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            ragDollPlayer.transform.position = transform.position;
            ragDollPlayer.GetComponent<Animator>().enabled = false;
            ragDollPlayer.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
