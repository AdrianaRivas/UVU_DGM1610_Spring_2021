using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellorRotate : MonoBehaviour
{
    private float rotationSpeed = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Make the propellor spin     
        transform.Rotate(Vector3.forward * rotationSpeed);
    }
}
