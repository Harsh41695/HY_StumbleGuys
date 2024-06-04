using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float x = 5, speed = 6;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveRight();
        if (transform.position.x <= -5)
        {
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }


    }
    void MoveRight()
    {
        transform.position += Vector3.right * (-speed) * Time.deltaTime;
    }
}
