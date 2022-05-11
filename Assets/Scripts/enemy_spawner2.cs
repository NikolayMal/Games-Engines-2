using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawner2 : MonoBehaviour
{
    private GameObject ally_mothership;
    public GameObject enemy_fighter;

    public GameObject[] enemy_fighter_count;

    public int Health = 100;
    private int count = 0;
    private int maxCount = 8;
    public GameObject explosion;

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
            // transform.position = Vector3.MoveTowards(transform.position, ally_mothership.transform.position, Time.deltaTime * 100);
        }

        enemy_fighter_count = GameObject.FindGameObjectsWithTag("enemy_fighter");
        if (enemy_fighter_count.Length < 60)
        {
            count = 0;
        }

        if (Health < 0)
        {
            Debug.Log("Ally Spawner Destroyed!");
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }


    }

    void Fighter()
    {
        if(count < maxCount) {
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y - 20, transform.position.z);
            GameObject fighter = Instantiate(enemy_fighter, spawnPosition, Quaternion.identity) as GameObject;
            // fighter.transform.parent = transform;
            count++;
        }
    }

    public void count_reset() {
        count = 0;
        maxCount = 50;
    }
}
