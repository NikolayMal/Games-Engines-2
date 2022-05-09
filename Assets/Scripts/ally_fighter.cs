using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ally_fighter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("circle", 5.0f);

        // Stop the movement of the fighter using transform
        transform.position = Vector3.MoveTowards(transform.position, transform.position, Time.deltaTime * 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void circle()
    {
        // disable script on ally_fighter
        gameObject.GetComponent<Boid>().enabled = false;
        gameObject.AddComponent<circle_mothership>();

    }
}
