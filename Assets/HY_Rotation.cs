using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HY_Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float speed = 10f;
    void Update()
    {
        transform.Rotate(Vector3.up*speed*Time.deltaTime);
    }
}
