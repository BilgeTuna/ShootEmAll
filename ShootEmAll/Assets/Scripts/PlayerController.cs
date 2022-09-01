using System.Collections;
using CodeMonkey.HealthSystemCM;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IGetHealthSystem
{
    public static PlayerController playerController;
    private Rigidbody rbody;
    private float moveForce = 8f;
    private Joystick joystick;
    private Animator anim;
    public ParticleSystem particle;
    public ParticleSystem updateParticle;
    private HealthSystem healthSystem;
    private bool onClicked = false;
    private float healthMax;
    public GameObject buttonCanvas;
    public GameObject healthBarCanvas;
    public Image barImage;

    void Awake()
    {
        particle.Stop();
        updateParticle.Stop();
        updateParticle.GetComponentInParent<MeshRenderer>().enabled = false;
        updateParticle.GetComponentInParent<SpawnEffect>().enabled = false;
        healthMax = 100;
        healthSystem = new HealthSystem(healthMax);
        healthSystem.OnDead += HealthSystem_OnDead;


        rbody = GetComponent<Rigidbody>();
        joystick = GameObject.FindWithTag("Joystick").GetComponent<DynamicJoystick>();
        anim = GetComponent<Animator>();

        //getHealthSystemGameObject = GameObject.FindGameObjectWithTag("Player");
    }

    public void DoubleHealth()
    {
        
        healthMax = 200;
        healthSystem.Damage(1f);
        healthBarCanvas.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1f, 1f);
        onClicked = true;
    }

    public void SpeedPlus()
    {
        moveForce = 12f;
        onClicked = true;
    }

    public void PillCvs()
    {
        barImage.GetComponent<Image>().fillAmount = 1;
        healthSystem.HealComplete();
    }

    private void HealthSystem_OnDead(object sender, System.EventArgs e)
    {
        //burası dolacak
        //gameObject.GetComponent<MeshRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag("Boy").GetComponent<SkinnedMeshRenderer>().enabled = false;
        particle.Play();
        StartCoroutine(delayDeath());
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<BoxCollider>().isTrigger = true;
            healthSystem.Damage(2f);
        }

        if (other.gameObject.CompareTag("Pill"))
        {
            PillCvs();
            //updateParticle.GetComponent<SphereCollider>().enabled = true;
            updateParticle.GetComponentInParent<MeshRenderer>().enabled = true;
            updateParticle.GetComponentInParent<SpawnEffect>().enabled = true;
            updateParticle.Play();
            Destroy(other.gameObject);
        }
    }

    IEnumerator delayDeath()
    {
        yield return new WaitForSeconds(.8f);
        //Destroy(gameObject);
        Time.timeScale = 0;
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

        if (onClicked == true)
        {
            buttonCanvas.SetActive(false);
        }
    }

    public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }
}

