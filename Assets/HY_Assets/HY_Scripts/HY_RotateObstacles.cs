using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HY_RotateObstacles : MonoBehaviour
{
    [SerializeField]
    float rotSpeed=2;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,rotSpeed*Time.deltaTime);
    }
}
