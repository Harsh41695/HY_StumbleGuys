using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastAi : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform m_transform;
    [SerializeField] private LayerMask layer;
    Rigidbody rb;
    [SerializeField]
    float moveSpeed = 5f;
    bool rotateOnce=false;
    RaycastHit hit;
    float maxdis;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
   

    void movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 dir = (transform.right * x + transform.forward * z).normalized;
        transform.position+=dir*moveSpeed*Time.deltaTime;
    }
    private void Update()
    {
        Physics.Raycast(transform.position,transform.forward,out hit,maxdis);
        Debug.DrawLine(transform.position,hit.point,Color.red);
    }
    void testTypeOne()
    {

        RaycastHit hit;
        if (Physics.Raycast(m_transform.position, m_transform.forward, out hit, 20f, layer))
        {
            //Vector3 randomDirection = Quaternion.Euler(Random.Range(-15f, 15f), Random.Range(-15f, 15f), 0) * transform.forward;
            //rb.MovePosition(transform.position + randomDirection * moveSpeed * Time.DeltaTime);


            Debug.Log("Ray Collide to ground");

            Debug.DrawLine(m_transform.position, m_transform.forward, Color.cyan);
        }
        else
        {
            if (!rotateOnce)
            {
                rotateOnce = true;
                Vector3 randomDirection = Quaternion.Euler(0, Random.Range(0f, 360f), 0) * transform.forward;
                rb.MoveRotation(Quaternion.LookRotation(randomDirection));
            }

            Debug.DrawLine(m_transform.position, m_transform.forward, Color.green);
            // Debug.DrawRay(m_transform.position, Vector3.forward, Color.green);
        }
    }
}
