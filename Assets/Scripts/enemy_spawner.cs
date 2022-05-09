using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawner : MonoBehaviour
{
    private GameObject ally_mothership;
    public GameObject enemy_fighter;

    // Start is called before the first frame update
    void Start()
    {
        // Rotate the ship X -90
        transform.Rotate(-90, 0, -180);

        // set target position to where ally mothership is
        ally_mothership = GameObject.FindWithTag("ally_mothership");
        InvokeRepeating("Fighter", 2.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards the target position if distance is greater than 200
        if (Vector3.Distance(transform.position, ally_mothership.transform.position) > 200)
        {
            transform.position = Vector3.MoveTowards(transform.position, ally_mothership.transform.position, Time.deltaTime * 100);
        }
        
    }

    void Fighter()
    {
        int count = transform.childCount;
        if(count < 30) {
            // Spawn fighter under the ally_spawnership
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y - 20, transform.position.z);
            // Quaternion spawnRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            GameObject fighter = Instantiate(enemy_fighter, spawnPosition, Quaternion.identity) as GameObject;
            fighter.transform.parent = transform;
            // fighter.AddComponent<NoiseWander>().axis = NoiseWander.Axis.Vertical;
            // fighter.AddComponent<NoiseWander>().axis = NoiseWander.Axis.Horizontal;
            // fighter.AddComponent<ObstacleAvoidance>();
            // fighter.AddComponent<Constrain>();
        }
    }
}
