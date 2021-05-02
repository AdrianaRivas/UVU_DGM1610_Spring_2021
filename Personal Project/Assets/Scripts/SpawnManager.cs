using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] obstacles;
    public GameObject powerupPrefab;

    private float spawnRange = 9.0f;

    public int enemyCount;
    public int obstacleCount;

    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn an enemy
        SpawnEnemyWave(waveNumber);

        // Spawn an obstacle
        SpawnObstacleWave(waveNumber);

        // Creates a powerup pickup for player to collect
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);  
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

            // Creates additional powerup pickups for the player to collect
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); 
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

    private Vector3 GenerateSpawnPosition()
    {
        // Generating random values for x and z
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        // Generating random position for enemy and obstacle
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            int randomIndex = Random.Range(0, enemies.Length);

            Instantiate(enemies[randomIndex], GenerateSpawnPosition(), enemies[randomIndex].gameObject.transform.rotation);
        }
    }

    void SpawnObstacleWave(int obstaclesToSpawn)
    {
        for(int i = 0; i < obstaclesToSpawn; i++)
        {
            int randomIndex = Random.Range(0, obstacles.Length);

            Instantiate(obstacles[randomIndex], GenerateSpawnPosition(), obstacles[randomIndex].gameObject.transform.rotation);
        }
    }    
}
