using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_fighter : MonoBehaviour
{
    public GameObject[] targets;
    public int random_target;
    public GameObject enemy_fighter_laser;

    public int Health = 100;
    // Start is called before the first frame update
    void Start()
    {  
       InvokeRepeating("find_targets", 1.0f, 20.0f);
       InvokeRepeating("fire_laser", 1.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (targets.Length > 0)
        {
            if (Vector3.Distance(transform.position, targets[random_target].transform.position) > 40)
            {
               transform.Translate(Vector3.forward * Time.deltaTime * 10);
            }
        }

        if (Health == 0)
        {
            Debug.Log("Ally Spawner Destroyed!");
            Destroy(gameObject);
        }
    }

    void find_targets()
    {
        // find all targets with tag enemy_spawner

        targets = GameObject.FindGameObjectsWithTag("ally_spawner");
        // if targets.leength is null

        if (targets.Length == 0) {
            targets = GameObject.FindGameObjectsWithTag("ally_fighter");
        }
        int random_target = Random.Range(0, targets.Length - 1);
        Debug.Log(random_target);
        transform.LookAt(targets[random_target].transform);
    }

    void fire_laser()
    {
        // instantiate a laser and send it to target, rotate lazer 90degrees
        GameObject laser = Instantiate(enemy_fighter_laser, transform.position, transform.rotation);
        // parent to fighter
        laser.transform.parent = gameObject.transform;
    }
}
