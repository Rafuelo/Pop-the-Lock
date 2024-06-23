using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public LogicScript logic; 
    public Transform center; // The center point of rotation
    public float speed = 20.0f; // Speed of rotation in degrees per second

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        center = GameObject.FindGameObjectWithTag("Base").GetComponent<Transform>();
    }

    void Update()
    {
        transform.RotateAround(center.position, logic.GetRotation(), speed * Time.deltaTime);
    }
}
