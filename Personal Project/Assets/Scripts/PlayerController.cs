using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 15.0f;
    private float xBound = 9.0f;
    private float zBound = 9.0f;
    public float horizontalInput;
    public float verticalInput;
    private GameObject player;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Squid");
        playerRb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    } 
    
    // Moves the player based on arrow key input
    void MovePlayer()
    {    
        // Allows the player to use arrow keys to move up/down and left/right
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        player.transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        player.transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }   
    
    // Prevents the player from leaving the screen
    void ConstrainPlayerPosition()
    {
        // Keeps the player from leaving both sides of the screen
        if(player.transform.position.x < -xBound)
        {
            player.transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
        if(player.transform.position.x > xBound)
        {
            player.transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        // Keeps the player from leaving top and bottom of the screen
        if(player.transform.position.z < -zBound)
        {
            player.transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
        if(player.transform.position.z > zBound)
        {
            player.transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy destroyed!"); 
        }

        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Player has collided with an obstacle!");
        }
    }
    
    // Power-up gets destroyed when it collides with player
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            Debug.Log("Collected power-up!");
        }
    }
}
