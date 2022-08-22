using System.Collections;
using System.Collections.Generic;

using CodeMonkey.HealthSystemCM;
using UnityEngine;

public class PlayerController : MonoBehaviour, IGetHealthSystem
{
    private Rigidbody rbody;
    public float moveForce = 10f;

    private Joystick joystick;

    private Animator anim;


    private HealthSystem healthSystem;


    void Awake()
    {
        healthSystem = new HealthSystem(100);
        healthSystem.OnDead += HealthSystem_OnDead;


        rbody = GetComponent<Rigidbody>();
        joystick = GameObject.FindWithTag("Joystick").GetComponent<DynamicJoystick>();
        anim = GetComponent<Animator>();

        //getHealthSystemGameObject = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        
    }

    private void HealthSystem_OnDead(object sender, System.EventArgs e)
    {
        //Destroy(gameObject);
    }

    public void Damage()
    {
        healthSystem.Damage(10);
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            Damage();
            Debug.Log("asddsfffg");
        }
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

    public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }
}

