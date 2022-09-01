using UnityEngine;

public class CamController : MonoBehaviour
{
    private Transform target;
    public Vector3 offset;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = target.position + offset;
    }
}
