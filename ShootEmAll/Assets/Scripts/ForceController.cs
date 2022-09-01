using System;
using System.Collections;
using UnityEngine;

public class ForceController : MonoBehaviour
{
    public GameObject bomb;
    private float power = 20.0f;
    private float radius = 10.0f;
    private float upforce = 1.0f;

    public ParticleSystem force;
    private bool onClicked = false;
    //private bool didTouch;
    public GameObject cvsButtonController;

    private void Awake()
    {
        force.Stop();
    }

    public void Force()
    {
        force.Play();
        Update();
        onClicked = true;
    }

    //bombshell
    private void FixedUpdate()
    {
        if (onClicked == true)
        {
            cvsButtonController.SetActive(false);
        }
    }

    private void Update()
    {
        InvokeRepeating("Detonate", 2, 1);
        InvokeRepeating("AntiDetonate", 3, 1);
    }

    void Detonate()
    {
      power = 20.0f;
      radius = 10.0f;
      upforce = 1.0f;

    force.Play();
        Vector3 explosionPosition = bomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upforce, ForceMode.Impulse);
            }
        }

        Debug.Log("anlamama yardımcı ol");
    }

    void AntiDetonate()
    {
        power = 0f;
        radius = 0f;
        upforce = 0f;
        Debug.Log("Allah'ın aşkına aydınlat beni");
    }
}