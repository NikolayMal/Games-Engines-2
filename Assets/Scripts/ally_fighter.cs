using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ally_fighter : MonoBehaviour
{
    public GameObject ally_fighter_laser;
    public GameObject explosion;
    public int Health = 50;

    public GameObject[] targets_enemy;
    public int random_target;
    private int check_1;
    private GameObject target;

    void Start()
    {
        InvokeRepeating("fire_laser", 1.0f, 5.0f);
        target = GameObject.FindWithTag("Planet");
        transform.position = Vector3.MoveTowards(transform.position, transform.position, Time.deltaTime * 0);
    }

    void Update()
    {
        if (Health <= 0)
        {
            Debug.Log("Ally fighter destroyed!");
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void circle()
    {
        gameObject.GetComponent<Boid>().enabled = false;
        gameObject.AddComponent<circle_mothership>();
    }

    void fire_laser()
    {
        targets_enemy = GameObject.FindGameObjectsWithTag("enemy_fighter");

        if (targets_enemy.Length == 0) {
            targets_enemy = GameObject.FindGameObjectsWithTag("enemy_spawner");
        }

        if(targets_enemy.Length > 0)
        {
            GameObject laser = Instantiate(ally_fighter_laser, transform.position + transform.forward * 10, Quaternion.Euler(90, 90, 90));
        }

    }

}
