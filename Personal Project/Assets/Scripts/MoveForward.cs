using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 10.0f;
    private float xRange = 14.0f;
    private float zRange = 14.0f;
    private Rigidbody enemyRb;
    private Rigidbody obstacleRb;
    private Rigidbody pickupRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        obstacleRb = GetComponent<Rigidbody>();
        pickupRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Squid");   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        // Set enemy direction toward player and go there
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
        // Set obstacle direction toward player and go there
        obstacleRb.AddForce(lookDirection * speed * Time.deltaTime);
        // Set pickup direction toward player and go there
        pickupRb.AddForce(lookDirection * speed * Time.deltaTime);

        // Destroy gameobject when out of bounds on the x-axis both sides
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            Destroy(gameObject);
        }
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            Destroy(gameObject);
        }
        
        // Destroy gameobject when out of bounds on the z-axis both sides
        if(transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
            Destroy(gameObject);
        }
        if(transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
            Destroy(gameObject);
        }    
    }
}
