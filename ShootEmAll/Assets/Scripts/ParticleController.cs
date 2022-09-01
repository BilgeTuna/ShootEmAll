using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public Transform target;
    public float orbitDistance = 1.0f;
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
}
