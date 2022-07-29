using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbody;
    public float moveForce = 10f;

    private Joystick joystick;

    private Animator anim;

    void Awake()
    {
        rbody = GetComponent<Rigidbody>();
        joystick = GameObject.FindWithTag("Joystick").GetComponent<DynamicJoystick>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        rbody.velocity = new Vector3(joystick.Horizontal * moveForce,
                                        rbody.velocity.y,
                                        joystick.Vertical * moveForce);

        if (joystick.Horizontal != 0f || joystick.Vertical != 0f)
        {
            anim.SetBool("isMoving", true);

            transform.rotation = Quaternion.LookRotation(rbody.velocity);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
}

