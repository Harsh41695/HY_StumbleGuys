
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Aniamtion_Workingtest : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Animator _charAnimator;
    bool isPressed;
    float velocity;
    void Start()
    {
        _charAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isPressed =Input.GetKey("w");
        if (isPressed && velocity < 1.0f)
        {
            velocity += Time.deltaTime * 0.1f;
            Debug.Log("calling");
        }
        if (!isPressed && velocity > 0.0f)
        {
            velocity -= Time.deltaTime * 0.5f;
        }
        if (!isPressed && velocity < 0.0f)
        {
            velocity= 0.0f;
        }
        _charAnimator.SetFloat("Velocity", velocity);
    }
}
