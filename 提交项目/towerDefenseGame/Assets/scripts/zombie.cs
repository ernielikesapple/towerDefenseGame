using UnityEngine;
using UnityEngine.UI;

public class zombie : MonoBehaviour
{
    public float startMoveSpeed = 0.5f;
    private Transform zombieCurrentMoveTo;  // guidePoint the zombie currently is moving to 
    private int currentMoveToIndex; // index for the zombie currently is moving to 



    [HideInInspector]
    public float speed;

    public float startHealth = 100;
    private float health;

    public int worth = 50;

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
            Destroy(gameObject);
            return;
        }
        currentMoveToIndex++;
        zombieCurrentMoveTo = guidePoints.guidePointsArray[currentMoveToIndex];
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        //healthBar.fillAmount = health / startHealth; //todo: add health bar
        Debug.Log("伤害血量：" + amount);
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startMoveSpeed * (1f - pct);
    }

    void Die()
    {
        isDead = true;

        //PlayerStats.Money += worth;  // todo: update PlayerStats

        //GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity); // todo: add death effect
        //Destroy(effect, 5f);

        //zombieSpawner.EnemiesAlive--;  // todo: update zombieSpawner

        Destroy(gameObject);
    }


}
