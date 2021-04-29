using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn an enemy
        SpawnEnemyWave(waveNumber);

        // Creates a powerup pickup for player to collect
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);  
    }

    // Update is called once per frame
    void Update()
    {
        // Find how many enemies are in play
        enemyCount = FindObjectsOfType<Enemy>().Length;
        // If enemy count gets down to zero, spawn new enemies in greater number
        if(enemyCount == 0)
        {
            waveNumber ++;
            SpawnEnemyWave(waveNumber);

            // Creates additional powerup pickups for the player to collect
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); 
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        // Generating random values for x and z
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        // Generating random position for enemy
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
