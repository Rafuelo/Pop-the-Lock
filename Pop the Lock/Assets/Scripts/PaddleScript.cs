using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public LogicScript logic; 
    public Transform center; // The center point of rotation
    public float speed = 20.0f; // Speed of rotation in degrees per second

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();


        Vector3 newPosition = transform.position = logic.GetRandomPosition();

        Vector3 direction = newPosition - center.position;

        float angleInDegrees = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleInDegrees - 90));
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(center.position, Vector3.forward, speed * Time.deltaTime);
    }
}
