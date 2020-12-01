using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class zombie : MonoBehaviour
{
    public float startMoveSpeed = 0.5f;
    private Transform zombieCurrentMoveTo;  // guidePoint the zombie currently is moving to 
    private int currentMoveToIndex; // index for the zombie currently is moving to 

    public Animator zAnimator;
    public AudioSource walkAudioSourceToPlay;
    public AudioSource getHurtAudioSourceToPlay;
    public AudioSource dieAudioSourceToPlay;

    [HideInInspector]
    public float speed;

    public float startHealth = 100;
    private float health;

    public int worth = 10;

    //public GameObject deathEffect; todo: add deathEffect

    [Header("Unity Stuff")]
    //public Image healthBar; // todo: add health bar

    public bool isDead = false;


    // Start is called before the first frame update
    void Start()
    {
        zombieCurrentMoveTo = guidePoints.guidePointsArray[0];
        transform.localScale = new Vector3(2f, 2f, 2f);
        speed = startMoveSpeed;
        health = startHealth;

        //todo: add take walk animation
        zAnimator.SetBool("walk",true);
        //todo: add take idle zombie sound
        walkAudioSourceToPlay.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = zombieCurrentMoveTo.position - transform.position;
        transform.Translate(moveDirection.normalized * startMoveSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, zombieCurrentMoveTo.position) <= 0.2f)
        {
            nextGuidePointInfo();

        }
    }

    void nextGuidePointInfo() { // get the next guide point the zombie should move to 
        if (currentMoveToIndex >= guidePoints.guidePointsArray.Length - 1) {
            
            zombieReachEndpoint();
            return;
        }
        currentMoveToIndex++;
        zombieCurrentMoveTo = guidePoints.guidePointsArray[currentMoveToIndex];
    }

    void zombieReachEndpoint() {

        playerInfo.Lives--;
        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("pao");
        //healthBar.fillAmount = health / startHealth; //todo: add health bar

        //todo: add take hit animation
        zAnimator.SetBool("walk", false);
        zAnimator.SetBool("getAttack", true);
        //todo: add take hit sound

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

    public void Slow(float pct)
    {
        speed = startMoveSpeed * (1f - pct);
    }

    void Die()
    {
        isDead = true;

        playerInfo.Money += worth;

        //GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity); // todo: add death effect
        //Destroy(effect, 5f);

        //zombieSpawner.EnemiesAlive--;  // todo: update zombieSpawner
        walkAudioSourceToPlay.Stop();
        //todo: add take Die animation
        zAnimator.SetBool("getAttack", true);
        //todo: add take Die sound
        dieAudioSourceToPlay.Play();
        Destroy(gameObject);
    }


}
