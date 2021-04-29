using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public int waveCount = 0;
    public int enemyCount;
    private float spawnRangeX = 10.0f;
    private float spawnZMin = 15.0f; // Set min spawn Z
    private float spawnZMax = 25.0f; // Set max spawn Z
    public float enemySpeed = 50.0f;
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public GameObject player;
    
    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0)
        {
            waveCount ++;
            SpawnEnemyWave(waveCount);
        }
    }

    // Generate random spawn position for powerups and enemy balls
    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        // Make powerups spawn at player end
        Vector3 powerupSpawnOffset = new Vector3(0, 0, -15);
        
        // If no powerups remain, spawn a powerup 
        if(GameObject.FindGameObjectsWithTag("Powerup").Length == 0) // Check that there are zero powerups
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition() + powerupSpawnOffset, powerupPrefab.transform.rotation);
        }

        // Spawn number of enemy balls based on wave number
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
        
        waveCount ++;
        enemyCount += 25;
        // Put player back at start
        ResetPlayerPosition(); 
    }

    // Move player back to position in front of own goal
    void ResetPlayerPosition()
    {
        player.transform.position = new Vector3(0, 1, -7);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
