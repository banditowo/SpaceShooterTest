using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab; // Reference to the enemy prefab
    public Transform spawnPoint1;  // First spawn point
    public Transform spawnPoint2;  // Second spawn point
    public float spawnInterval; // Time between spawns

    private float timeSinceLastSpawn;

    void Start()
    {
        timeSinceLastSpawn = spawnInterval; // Start spawning immediately
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f;
        }
    }

    void SpawnEnemy()
    {
        // Calculate random position between spawnPoint1 and spawnPoint2
        float randomX = Random.Range(spawnPoint1.position.x, spawnPoint2.position.x);
        float randomY = Random.Range(spawnPoint1.position.y, spawnPoint2.position.y);
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        // Instantiate the enemy at the calculated position
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }


    //[SerializeField] private float spawnRate = 1f;
    //[SerializeField] private GameObject[] enemyPrefab;
    //[SerializeField] private bool canSpawn = true;


    //void Start()
    //{
    //    StartCoroutine(Spawner());
    //}

    //private IEnumerator Spawner()
    //{
    //    WaitForSeconds wait = new WaitForSeconds(spawnRate);

    //    while (canSpawn)
    //    {
    //        yield return wait;

    //        Instantiate(enemyPrefab[0], transform.position, Quaternion.identity);
    //    }
    //}

}
