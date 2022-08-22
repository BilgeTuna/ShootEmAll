using System.Collections;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public ParticleSystem particle;

    //public Transform target;
    public float speed = 5f;
    Rigidbody rig;


    private void Awake()
    {
        particle.Stop();
    }

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        rig.MovePosition(pos);
        transform.LookAt(target);
    }

    IEnumerator delayDeath()
    {
        yield return new WaitForSeconds(.6f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gun"))
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            particle.Play();
            StartCoroutine(delayDeath());    
        }
    }
}
