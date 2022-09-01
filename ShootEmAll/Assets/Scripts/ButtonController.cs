using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject rocketLvl1;
    /*
    public GameObject rocketLvl2;
    public GameObject rocketLvl3;
    public GameObject rocketLvl4;
    public GameObject rocketLvl5;
    public GameObject rocketLvl6;
    public GameObject rocketLvl7;
    public GameObject rocketLvl8;
    */

    /*
    public GameObject rayLvl1;
    public GameObject rayLvl2;
    public GameObject rayLvl3;
    public GameObject rayLvl4;
    public GameObject rayLvl5;
    public GameObject rayLvl6;
    public GameObject rayLvl7;
    public GameObject rayLvl8;
    */

    public ParticleSystem rayLvl1;
    public GameObject buttonCanvas;
    private int numLevel = 1;
    private bool onClicked = false;
    

    void Awake()
    {
        rayLvl1.Stop();
    }

    private void Start()
    {

    }

    public void Rocket()
    {
        //SpreadRocket();
        rocketLvl1.SetActive(true);
        rocketLvl1.tag = "Rocket";
        rocketLvl1.GetComponent<CapsuleCollider>().enabled = true;
        onClicked = true;
    }

    public void Ray()
    {
        rayLvl1.Play();
        rayLvl1.tag = "Ray";
        rayLvl1.GetComponent<BoxCollider>().enabled = true;
        onClicked = true;
    }

    private void Update()
    {
        if (onClicked == true)
        {
            buttonCanvas.SetActive(false);
        }
    }
}
