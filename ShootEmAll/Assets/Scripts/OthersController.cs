using UnityEngine;
using UnityEngine.AI;

public class OthersController : MonoBehaviour
{
    public Transform target;
    public Transform myTransform;

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * 3 * Time.deltaTime);
        //transform.rotation = Quaternion.Euler(90f, transform.localRotation.y, transform.localRotation.z);
        //transform.position = new Vector3(transform.localPosition.x, 0.653f, transform.localPosition.z);
    }
}
