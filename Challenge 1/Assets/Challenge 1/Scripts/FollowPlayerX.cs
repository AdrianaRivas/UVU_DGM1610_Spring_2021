using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Offset camera position by plane position
        offset = transform.position - plane.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Update camera position
        transform.position = plane.transform.position + offset;
    }
}
