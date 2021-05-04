using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 5.0f;
    private float zDestroy = -9.0f;

    private Rigidbody enemyRb;
    private Rigidbody obstacleRb;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        obstacleRb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction toward player and go there
        enemyRb.AddForce(Vector3.forward * -speed);
        // Set obstacle direction toward player and go there
        obstacleRb.AddForce(Vector3.forward * -speed);
        
        // Destroy gameobject when out of bounds on the z-axis both sides
        if(transform.position.z < zDestroy)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed!");
        }    
    }
}
