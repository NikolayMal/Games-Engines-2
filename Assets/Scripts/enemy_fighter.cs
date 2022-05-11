using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_fighter : MonoBehaviour
{
    public GameObject[] targets;
    public int random_target;
    public GameObject enemy_fighter_laser;
    public int Health = 10;
    public int second_wave_check = 0;

    void Start()
    {  
       InvokeRepeating("find_targets", 1.0f, 7.5f);
       InvokeRepeating("fire_laser", 1.0f, 5.0f);
    }

    void Update()
    {
        if (targets.Length > 0 && second_wave_check == 0)
        {
            if (Vector3.Distance(transform.position, targets[random_target].transform.position) > 60)
            {
               transform.Translate(Vector3.forward * Time.deltaTime * 20);
            }
        }

        if (targets.Length > 0 && second_wave_check == 1)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 20);
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

        if (targets.Length == 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 0);
        }
        if (targets.Length > 0) {
            transform.LookAt(targets[random_target].transform);
        }
    }

    void fire_laser()
    {
        if (targets.Length > 0)
        {
            GameObject laser = Instantiate(enemy_fighter_laser, transform.position , transform.rotation);
            laser.transform.parent = gameObject.transform;
        }
    }

    public void second_wave_check_func() {
        second_wave_check = 1;
    }
}
