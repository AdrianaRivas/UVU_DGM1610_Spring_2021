using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] obstacles;
    public GameObject powerup;

    private float zEnemySpawn = 10.0f;
    private float zObstacleSpawn = 10.0f;
    private float xSpawnRange = 18.0f;
    private float zPowerupRange = 5.0f;
    private float ySpawn = 0.75f;

    public int enemyCount;
    public int obstacleCount;

    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
        SpawnPowerup();
        SpawnObstacle();
        
        GenerateSpawnPosition();

        // Spawn an enemy
        SpawnEnemyWave(waveNumber);

        // Spawn an obstacle
        SpawnObstacleWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        // Find how many enemies are in play
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        // If enemy count gets down to zero, spawn new enemies in greater number
        if(enemyCount == 0)
        {
            waveNumber ++;
            SpawnEnemyWave(waveNumber); 
        }

        // Find how many obstacles are in play
        obstacleCount = GameObject.FindGameObjectsWithTag("Obstacle").Length;
        // If obstacle count gets down to zero, spawn new obstacles in greater number
        if(obstacleCount == 0)
        {
            waveNumber ++;
            SpawnObstacleWave(waveNumber);
        }
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0,enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }

    void SpawnObstacle()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0,obstacles.Length);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, zObstacleSpawn);

        Instantiate(obstacles[randomIndex], spawnPos, obstacles[randomIndex].gameObject.transform.rotation);
    }

     void SpawnPowerup()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-zPowerupRange, zPowerupRange);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);

        Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        // Generating random values for x and z
        float spawnPosX = Random.Range(-xSpawnRange, xSpawnRange);
        float spawnPosZ = Random.Range(-zPowerupRange, zPowerupRange);
        // Generating random position for enemy and obstacle
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            int randomIndex = Random.Range(0, enemies.Length);

            GameObject enemy = Instantiate(enemies[randomIndex], GenerateSpawnPosition(), enemies[randomIndex].gameObject.transform.rotation);
        }
    }

    void SpawnObstacleWave(int obstaclesToSpawn)
    {
        for(int i = 0; i < obstaclesToSpawn; i++)
        {
            int randomIndex = Random.Range(0, obstacles.Length);

            GameObject obstacle = Instantiate(obstacles[randomIndex], GenerateSpawnPosition(), obstacles[randomIndex].gameObject.transform.rotation);
        }
    }    
}
