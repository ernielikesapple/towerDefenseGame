using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class zombie : MonoBehaviour
{
    public float startMoveSpeed = 0.5f;
   
    public Animator zAnimator;
    public AudioSource walkAudioSourceToPlay;
    public AudioSource getHurtAudioSourceToPlay;
    public AudioSource dieAudioSourceToPlay;

    [HideInInspector]
    public float speed;

    public float startHealth = 100;
    private float health;

    public int worth = 10;

    [Header("health bar stuff")]
    public Image healthBar;

    public bool isDead = false;


    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        walkAudioSourceToPlay = audios[0];
        getHurtAudioSourceToPlay = audios[1];
        dieAudioSourceToPlay = audios[2];

        // transform.localScale = new Vector3(2f, 2f, 2f);
        speed = startMoveSpeed;
        health = startHealth;

        zAnimator.SetBool("walk",true);
        walkAudioSourceToPlay.Play();

    }



    void Update()
    {
        

    }


    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth; 

        zAnimator.SetBool("walk", false);
        zAnimator.SetBool("getAttack", true);

        StartCoroutine(ShowMessage(0.5f));

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }


    IEnumerator ShowMessage(float delay)  // this piece is crucial to add , need to do the animation transition in an asyc way
    {
        
        yield return new WaitForSeconds(delay);
       
        zAnimator.SetBool("getAttack", false);
        getHurtAudioSourceToPlay.Play();
        zAnimator.SetBool("walk", true);
    }

    void Die()
    {
        isDead = true;

        playerInfo.Money += worth;

        zombieSpawner.EnemiesAlive--; 
        zAnimator.SetBool("getAttack", true);
        dieAudioSourceToPlay.Play();
        Destroy(gameObject);
    }


}
