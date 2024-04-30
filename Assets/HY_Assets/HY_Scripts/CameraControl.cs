using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    //[Header("Camera Control with Joystick")]

    [SerializeField]
    float dis = 3f, minY = -50f, maxY = 50,
        sensivity = 200f, speed, sensivityY = 60;
    float yDeg, xDeg;
    Vector2 startPos, direction;

    [SerializeField]
    Transform lookAt, player;
    Quaternion rot;

    float currentY = 0, currentX = 0;
    //[SerializeField]
    //FloatingJoystick floatJoyStick;
    [SerializeField]
    Vector3 dir;

    public FixedTouchField TouchField;
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
        currentX += TouchField.TouchDist.x * sensivity * Time.deltaTime;
        currentY -= TouchField.TouchDist.y * sensivityY * Time.deltaTime;

        currentY = Mathf.Clamp(currentY, minY, maxY);
        if (TouchField.TouchDist.x > 0.1 || TouchField.TouchDist.x < -0.1 ||
                     TouchField.TouchDist.y > 0.1 || TouchField.TouchDist.y < -0.1)
        {
            rot = Quaternion.Euler(currentY, currentX, 0);

        }
        dir = new Vector3(0, 0, -dis);
        transform.position = lookAt.position + rot * dir;
        transform.LookAt(lookAt.position);

    }
}