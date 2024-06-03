using UnityEngine;

public class TestLevel_4Ai : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform faceTrans;
    Rigidbody rb;
    [SerializeField]
    float maxDistace, force = 10f;
    bool isGrounded;
    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //RayForward();
        BackwardRayCast();
    }
    void RayForward()
    {
        RaycastHit hit;
        if (Physics.Raycast(faceTrans.position, faceTrans.forward, out hit, maxDistace))
        {
            DoJump();
            Debug.DrawLine(faceTrans.position, hit.point, Color.red);
        }
        else
        {
            Debug.DrawLine(faceTrans.position, faceTrans.forward * maxDistace, Color.green);
        }
    }
    private void BackwardRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(faceTrans.position, -faceTrans.forward, out hit, maxDistace))
        {
            if (hit.collider.tag == "Wall")
            {
                DoJump();
            }
            Debug.DrawLine(faceTrans.position, hit.point, Color.red);
        }

    }
    void DoJump()
    {
        //isGrounded = false;
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        animator.SetBool("Jump", true);
        animator.SetBool("Hanging", true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("Jump", false);
            animator.SetBool("Hanging", false);
        }
    }
}
