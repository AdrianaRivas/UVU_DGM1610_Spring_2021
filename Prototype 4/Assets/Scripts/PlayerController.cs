using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed;
    public float powerupStrength = 16.0f;
    public GameObject powerupIndicator;
    private GameObject focalPoint;
    public bool hasPowerup;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * Time.deltaTime);

        powerupIndicator.transform.position = transform.position + new Vector3(0, 0.5f, 0);
    }

    // Allows the player to pickup powerup item
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            Debug.Log("Powerup Collected!");

            StartCoroutine(PowerupCountdownRoutine());

            powerupIndicator.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            // Gets the enemies rigidbody component to have access to its physics properties
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            // Gets the position of the enemy in relation to the player
            Vector3 awayFromplayer = (collision.gameObject.transform.position - transform.position);
            // Report player collision with pickup
            Debug.Log("Player has collided with " + collision.gameObject + " with powerup set to " + hasPowerup);
            // On collision kicks enemy back
            enemyRigidbody.AddForce(awayFromplayer * powerupStrength, ForceMode.Impulse);
        }
    }
    
    // Allows powerup to return to game after the countdown has finished
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7); hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
