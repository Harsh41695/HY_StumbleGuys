using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class HY_CameraRotation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float yDeg, xDeg,speed = 50f,distance = 3, minY,maxY,sensivity;
    Vector2 startPos,direction;
    [SerializeField]
    Transform lookAt;
    Quaternion rot;
    float currentY=0 , currentX=0; 
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        //TouchControl();
    }
    private void LateUpdate()
    {
        MouseRotation();
       TouchControl();
    }

    public void TouchControl()
    {
        if (Input.touchCount > 0)
        {
            if(Input.touchCount < 2)
            {
                Touch myTouch = Input.GetTouch(0);
                if (myTouch.phase == TouchPhase.Began || myTouch.phase == TouchPhase.Stationary)
                {
                    startPos = myTouch.position;
                }
                if (myTouch.phase == TouchPhase.Moved)
                {
                    direction = myTouch.position - startPos;
                    direction.Normalize();

                    yDeg = direction.y*speed*Time.deltaTime;
                    xDeg = direction.x*speed*Time.deltaTime;
                    #region
                    yDeg += transform.rotation.eulerAngles.x;
                    if (yDeg < 180f && yDeg > 25f)
                    {
                        yDeg = 25f;
                    }
                    else if (yDeg >= 180f && yDeg < 340f)
                    {
                        yDeg = 340f;
                    }
                    #endregion
                   // yDeg = Mathf.Clamp(yDeg, minY, maxY);

                    xDeg += transform.rotation.eulerAngles.y;
                    rot = Quaternion.Euler(yDeg, xDeg, 0);

                    transform.rotation = rot;
                    transform.LookAt(lookAt.position);
                }
            }
        }
    }
    public void MouseRotation()
    {
        currentX += Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        currentY += Input.GetAxis("Mouse Y") *-1* sensivity * Time.deltaTime;

        currentY = Mathf.Clamp(currentY, minY, maxY);

        Vector3 dir = new Vector3(0, 3, -distance);

        rot = Quaternion.Euler(currentY, currentX, 0);

        transform.position = lookAt.position + rot * dir;
        transform.LookAt(lookAt.position);
    }
}
