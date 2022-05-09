using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ally_fighter : MonoBehaviour
{
    public GameObject ally_fighter_laser;
    public int Health = 50;

    public GameObject[] targets_ally;
    public int random_target;

    // Start is called before the first frame update
    void Start()
    {
        // Invoke("circle", 5.0f);
        InvokeRepeating("fire_laser", 1.0f, 5.0f);

        // Stop the movement of the fighter using transform
        transform.position = Vector3.MoveTowards(transform.position, transform.position, Time.deltaTime * 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Debug.Log("Ally fighter destroyed!");
            Destroy(gameObject);
        }
    }

    void circle()
    {
        // disable script on ally_fighter
        gameObject.GetComponent<Boid>().enabled = false;
        gameObject.AddComponent<circle_mothership>();

    }

    void fire_laser()
    {
        targets_ally = GameObject.FindGameObjectsWithTag("enemy_fighter");

        if (targets_ally.Length == 0) {
            targets_ally = GameObject.FindGameObjectsWithTag("enemy_spawner");
        }

        if(targets_ally.Length > 0)
        {
            random_target = Random.Range(0, targets_ally.Length - 1);
            Debug.Log(random_target);
            transform.LookAt(targets_ally[random_target].transform);

            // instantiate laser infront of the fighter
            GameObject laser = Instantiate(ally_fighter_laser, transform.position + transform.forward * 10, transform.rotation);
            // laser.transform.parent = gameObject.transform;
        }

    }
}
