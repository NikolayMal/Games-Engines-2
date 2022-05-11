using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawner : MonoBehaviour
{
    private GameObject ally_mothership;
    public GameObject enemy_fighter;
    public int Health = 100;
    private int count = 0;

    void Start()
    {
        transform.Rotate(-90, 0, -180);

        ally_mothership = GameObject.FindWithTag("ally_mothership");
        InvokeRepeating("Fighter", 2.0f, 1.0f);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, ally_mothership.transform.position) > 200)
        {
            transform.position = Vector3.MoveTowards(transform.position, ally_mothership.transform.position, Time.deltaTime * 30);
        }

        if (Health < 0)
        {
            Debug.Log("Ally Spawner Destroyed!");
            Destroy(gameObject);
        }
    }

    void Fighter()
    {
        if(count < 5) {
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y - 20, transform.position.z);
            GameObject fighter = Instantiate(enemy_fighter, spawnPosition, Quaternion.identity) as GameObject;
            fighter.transform.parent = transform;
            // fighter.AddComponent<NoiseWander>().axis = NoiseWander.Axis.Vertical;
            // fighter.AddComponent<NoiseWander>().axis = NoiseWander.Axis.Horizontal;
            // fighter.AddComponent<ObstacleAvoidance>();
            // fighter.AddComponent<Constrain>();
            count++;
        }
    }
}
