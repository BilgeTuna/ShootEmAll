using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform target;
    public float orbitDistance = 2.0f;
    public float orbitDegreesPerSec = 0.0f;

    void Orbit()
    {
        if (target != null)
        {
            //position asıl değeri
            transform.position = target.position + (transform.position - target.position).normalized * orbitDistance;
            transform.RotateAround(target.position, Vector3.up, orbitDegreesPerSec * Time.deltaTime);
        }
    }

    void LateUpdate()
    {

        Orbit();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }

    private void FirstBtnOnClick()
    {
        orbitDistance = 3.0f;

    }
}
