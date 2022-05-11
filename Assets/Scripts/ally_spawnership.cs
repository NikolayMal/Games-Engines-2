using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ally_spawnership : MonoBehaviour
{
    public float speed = 50f;
    private GameObject ally_mothership;
    public GameObject ally_fighter;
    Vector3 worldTarget;
    Vector3 offset;
    public int Health = 1000;
    public int count = 0;
    public int count2 = 0;
    public GameObject explosion;

    public void OnEnable() {
        InvokeRepeating("Fighter", 2.0f, 4.0f);
    }

    void Start()
    {
        ally_mothership = GameObject.FindWithTag("ally_mothership");
        offset = transform.position - ally_mothership.transform.position;
        offset = Quaternion.Inverse(ally_mothership.transform.rotation) * offset;


        transform.parent = ally_mothership.transform;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, ally_mothership.transform.position) < 50)
        {
            worldTarget = ally_mothership.transform.TransformPoint(offset);
            transform.position = Vector3.MoveTowards(transform.position, worldTarget, speed * Time.deltaTime);
        }

        if (Health <= 0)
        {
            Debug.Log("Ally Spawner Destroyed!");
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void Fighter()
    {
        
        if(count < 10) {
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y - 20, transform.position.z);
            GameObject fighter = Instantiate(ally_fighter, spawnPosition, Quaternion.identity) as GameObject;
            fighter.transform.parent = ally_mothership.transform;
            fighter.AddComponent<NoiseWander>().axis = NoiseWander.Axis.Vertical;
            fighter.AddComponent<NoiseWander>().axis = NoiseWander.Axis.Horizontal;
            fighter.AddComponent<ObstacleAvoidance>();
            fighter.AddComponent<Constrain>();

            count++;
        }
    }

    void Fighter2()
    {
        
        if(count2 < 10) {
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y - 20, transform.position.z);
            GameObject fighter = Instantiate(ally_fighter, spawnPosition, Quaternion.identity) as GameObject;
            fighter.transform.parent = ally_mothership.transform;
            fighter.AddComponent<NoiseWander>().axis = NoiseWander.Axis.Vertical;
            fighter.AddComponent<NoiseWander>().axis = NoiseWander.Axis.Horizontal;
            fighter.AddComponent<ObstacleAvoidance>();
            fighter.AddComponent<Constrain>();

            count2++;
        }
    }

    public void spawn_again()
    {
        InvokeRepeating("Fighter2", 0.1f, 1.0f);
    }
}
