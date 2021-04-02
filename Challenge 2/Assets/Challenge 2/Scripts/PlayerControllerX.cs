using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float spawnDelay = 1.0f;

    // Update is called once per frame
    void Update()
    {
        // Dog spawns once per second
        spawnDelay += Time.deltaTime;
        if (spawnDelay > 1.0f)
        {
            spawnDelay = 0.0f;
        }
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
