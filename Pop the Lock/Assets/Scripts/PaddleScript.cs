using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public Transform center; // The center point of rotation
    public float speed = 20.0f; // Speed of rotation in degrees per second

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(center.position, Vector3.forward, speed * Time.deltaTime);
    }
}
