using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScircleScript : MonoBehaviour
{
    public LogicScript logic;
    public Transform center; // The center point of rotation
    private bool isWithinTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        center = GameObject.FindGameObjectWithTag("Base").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isWithinTrigger)
            {
                logic.RemoveScore();
                Destroy(gameObject);
            }
            else
            {
                logic.Lose();
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isWithinTrigger = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isWithinTrigger = false;
    }
}
