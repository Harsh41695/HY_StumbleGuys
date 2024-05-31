using UnityEngine;

public class RayCastAi : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform m_transform;
    [SerializeField] private LayerMask layer;
    Rigidbody rb;
    [SerializeField]
    float moveSpeed = 5f, force = 7f;
    bool rotateOnce = false;
    RaycastHit hit;
    [SerializeField] private float maxdis = 100f;
    float time;
    Vector3 randomDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    //void movement()
    //{
    //    float x = Input.GetAxis("Horizontal");
    //    float z = Input.GetAxis("Vertical");
    //    Vector3 dir = (transform.right * x + transform.forward * z).normalized;
    //    transform.position += dir * moveSpeed * Time.deltaTime;
    //}
    private void Update()
    {

        if (Physics.Raycast(m_transform.position, m_transform.forward, out hit, maxdis))
        {
            // if (!rotateOnce)

            if (hit.collider.tag == "Wall")
            {
                Vector3 randomDirection = Quaternion.Euler(0, Random.Range(0f, 360f), 0) * transform.forward;
                rb.MoveRotation(Quaternion.LookRotation(randomDirection));
            }

            Debug.DrawLine(m_transform.position, hit.point, Color.red);
        }
        else
        {
            Vector3 randomDirection = Quaternion.Euler(Random.Range(-15f, 15f), Random.Range(-15f, 15f), 0) * transform.forward;
            rb.MovePosition(transform.position + randomDirection * moveSpeed * Time.deltaTime);
            time += Time.deltaTime;
            if (time > 0.25f)
            {
                rb.AddForce(Vector3.up * force, ForceMode.Impulse);
                rb.MoveRotation(Quaternion.LookRotation(RandoRoatation()));
                time = 0f;
            }
            Debug.DrawLine(m_transform.position, m_transform.forward * maxdis, Color.green);
        }


    }
    Vector3 RandoRoatation()

    {
        return  randomDirection = Quaternion.Euler(0, Random.Range(0f, 360f), 0) * transform.forward;
    }

}
