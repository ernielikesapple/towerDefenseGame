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

    [Header("Unity Stuff")]
    //public Image healthBar; // todo: add health bar

    public bool isDead = false;


    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(2f, 2f, 2f);
        speed = startMoveSpeed;
        health = startHealth;

        //todo: add take walk animation
        zAnimator.SetBool("walk",true);
        //todo: add take idle zombie sound
        walkAudioSourceToPlay.Play();
    }

   


    

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("pao");
        //healthBar.fillAmount = health / startHealth; //todo: add health bar

        zAnimator.SetBool("walk", false);
        zAnimator.SetBool("getAttack", true);

        getHurtAudioSourceToPlay.Play();

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
        zAnimator.SetBool("walk", true);
    }

    void Die()
    {
        isDead = true;

        playerInfo.Money += worth;

        //zombieSpawner.EnemiesAlive--;  // todo: update zombieSpawner
        walkAudioSourceToPlay.Stop();
        zAnimator.SetBool("getAttack", true);
        dieAudioSourceToPlay.Play();
        Destroy(gameObject);
    }


}
