using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] obstacles;
    public GameObject powerup;
    private float zEnemySpawn = 9.0f;
    private float zObstacleSpawn = -9.0f;
    private float xSpawnRange = 12.0f;
    private float zPowerupRange = 5.0f;
    private float ySpawn = 0.5f;
    private float powerupSpawnTime = 5.0f;
    private float obstacleSpawnTime = 0.5f;
    private float enemySpawnTime = 0.5f;
    private float startDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnRandomObstacle", startDelay, obstacleSpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
    }

    // Enemy spawns in a random range
    void SpawnRandomEnemy()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }

    // Obstacle spawns in a random range
    void SpawnRandomObstacle()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, obstacles.Length);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, zObstacleSpawn);

        Instantiate(obstacles[randomIndex], spawnPos, obstacles[randomIndex].gameObject.transform.rotation);
    }

    // Power-up spawns in a random range
    void SpawnPowerup()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-zPowerupRange, zPowerupRange);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);

        Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
    }
}
