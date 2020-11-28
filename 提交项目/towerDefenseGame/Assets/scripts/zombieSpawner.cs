using System.Collections;
using UnityEngine;

public class zombieSpawner : MonoBehaviour
{
    public Transform zombie1Prefab;

    private Transform orignalSpawnLocation;

    public float timeBetweenSpawn = 3f;
    private float nextWaveTimer = 2f;

    private int spawnWaveNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject emptyGO = new GameObject();  // set intial spawn location
        emptyGO.transform.position = new Vector3(-2.44f, 0.8f, 2.03f);
        emptyGO.transform.rotation = Quaternion.Euler(0, 90, 0);
        orignalSpawnLocation = emptyGO.transform; 



    }

    // Update is called once per frame
    void Update()
    {
        if (nextWaveTimer <= 0f) {
            StartCoroutine(SpwanZombiesWaves());
            nextWaveTimer = timeBetweenSpawn;
        }
        nextWaveTimer -= Time.deltaTime;
    }

    IEnumerator SpwanZombiesWaves() { // pause this piece of code, wait certain time before continuing

        spawnWaveNumber++; // spawn more zombies for next waves
        for (int i = 0; i < spawnWaveNumber; i++)
        {
            SpwanZombies();
            yield return new WaitForSeconds(0.8f);
        }
    }


    void SpwanZombies()
    {
        Instantiate(zombie1Prefab, orignalSpawnLocation.position, orignalSpawnLocation.rotation);
    }

}
