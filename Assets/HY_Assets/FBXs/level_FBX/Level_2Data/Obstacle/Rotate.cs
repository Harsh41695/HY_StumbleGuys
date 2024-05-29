using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotSpeed = 20;
    float time;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    [System.Obsolete]
    void FixedUpdate()
    {

        TransformRotation();
    }
    void TorqueRotation()
    {
        rb.AddTorque(Vector3.forward * rotSpeed * Time.deltaTime, ForceMode.Impulse);
    }
    [System.Obsolete]
    void TransformRotation()
    {
        transform.rotation *= Quaternion.EulerRotation(new Vector3(0, 0, 1*rotSpeed * Time.deltaTime));
    }
}
