using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_fighter : MonoBehaviour
{
    public GameObject[] targets;
    public int random_target;
    public GameObject enemy_fighter_laser;

    public int Health = 10;
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
               transform.Translate(Vector3.forward * Time.deltaTime * 50);
            }
        }

        if (Health <= 0)
        {
            Debug.Log("Enemy fighter Destroyed!");
            Destroy(gameObject);
        }
    }

    void find_targets()
    {
        targets = GameObject.FindGameObjectsWithTag("ally_spawner");

        if (targets.Length == 0) {
            targets = GameObject.FindGameObjectsWithTag("ally_fighter");
        }
        random_target = Random.Range(0, targets.Length - 1);
        Debug.Log(random_target);
        transform.LookAt(targets[random_target].transform);
    }

    void fire_laser()
    {
        if (targets.Length > 0)
        {
            GameObject laser = Instantiate(enemy_fighter_laser, transform.position , transform.rotation);
            laser.transform.parent = gameObject.transform;
        }
    }
}
