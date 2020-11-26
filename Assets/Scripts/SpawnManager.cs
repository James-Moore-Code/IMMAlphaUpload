using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] pickUps;

    private float xSpawnRange =  25.0f;
    private float zSpawnRange = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 10.0f, 10.0f);
        InvokeRepeating("SpawnPickUps", 15.0f, 12.0f);
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-zSpawnRange, zSpawnRange);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, 0.5f, randomZ);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }

    void SpawnPickUps()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-zSpawnRange, zSpawnRange);
        int randomIndex = Random.Range(0, pickUps.Length);

        Vector3 spawnPos = new Vector3(randomX, 0.3f, randomZ);

        Instantiate(pickUps[randomIndex], spawnPos, pickUps[randomIndex].gameObject.transform.rotation);
    }
}
