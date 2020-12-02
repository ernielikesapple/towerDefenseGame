using System.Collections;
using UnityEngine;

public class zombieSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;

    private Transform orignalSpawnLocation;

    public float timeBetweenSpawn = 3f;
    private float nextWaveTimer = 2f;

    public OverallControl gameManager;

    private int spawnWaveNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject emptyGO = new GameObject();  // set intial spawn location
        emptyGO.transform.position = new Vector3(-2.44f, 0.8f, 2.03f);
        emptyGO.transform.rotation = Quaternion.Euler(0, 90, 0);
        orignalSpawnLocation = emptyGO.transform;

        spawnWaveNumber = 0;
        EnemiesAlive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemiesAlive > 0)
        {            
            return;
        }

        if (spawnWaveNumber == waves.Length)
        {
            gameManager.WinLevel();  //todo: update it's wininig
            Debug.Log("winnning");
            this.enabled = false;
        }

        if (nextWaveTimer <= 0f) {
            StartCoroutine(SpwanZombiesWaves());
            nextWaveTimer = timeBetweenSpawn;
            return;
        }
        nextWaveTimer -= Time.deltaTime;
    }

    IEnumerator SpwanZombiesWaves() { // pause this piece of code, wait certain time before continuing

        playerInfo.Rounds++;

        Wave wave = waves[spawnWaveNumber];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpwanZombies(wave.zombie);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        spawnWaveNumber++; // spawn more zombies for next waves
    }


    void SpwanZombies(GameObject zombie)
    {
        Instantiate(zombie, orignalSpawnLocation.position, orignalSpawnLocation.rotation);
    }

}
