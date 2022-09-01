using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public ParticleSystem shield;
    private bool onClicked = false;
    private bool didTouch;
    public GameObject cvsButtonController;

    private void Start()
    {
        shield.Stop();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            didTouch = true;
        }
    }

    public void Shield()
    {
        shield.Play();
        onClicked = true;
        shield.tag = "Shield";
        shield.GetComponent<CapsuleCollider>().enabled = true;
    }

    private void Update()
    {
        if (onClicked == true)
        {
            cvsButtonController.SetActive(false);
        }

        if (didTouch == true)
        {
            shield.Stop();
            shield.GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
