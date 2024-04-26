using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HY_FloatingJoyStick_Camera_Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    //[Header("Camera Control with Joystick")]
    
    [SerializeField] float dis = 3f, minY=-50f, maxY=50,
        sensivity=200f,speed, sensivityY=60;
    float yDeg, xDeg;
    Vector2 startPos, direction;
   
    [SerializeField]
    Transform lookAt,player;
    Quaternion rot;
   
    float currentY = 0, currentX = 0;
    [SerializeField]
    FloatingJoystick floatJoyStick;
    [SerializeField]
    Vector3 dir;
    private void Start()
    {
        rot = Quaternion.Euler(28, 0, 0);

    }
    private void LateUpdate()
    {
        MouseRotation();
      
    }

    
    public void MouseRotation()
    {
        currentX += floatJoyStick.Horizontal * sensivity * Time.deltaTime;
        currentY -= floatJoyStick.Vertical * sensivityY * Time.deltaTime;
        print(currentX);
        currentY = Mathf.Clamp(currentY, minY, maxY);
        if (floatJoyStick.Horizontal >= 0.01f || floatJoyStick.Horizontal <= -0.01f ||
            floatJoyStick.Vertical >= 0.01f || floatJoyStick.Vertical <= -0.01f)
        {
            rot = Quaternion.Euler(currentY, currentX, 0);

        }
        dir = new Vector3(0, 0, -dis);
        transform.position = lookAt.position + rot * dir;
        transform.LookAt(lookAt.position);

    }
}
