using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_ally_fighter : MonoBehaviour
{
    private int damage = 10;
    public GameObject[] targets_enemy;
    public GameObject[] targets_spawner;

    void Start()
    {
        Invoke("Destroy", 7.0f);

        targets_enemy = GameObject.FindGameObjectsWithTag("enemy_fighter");
        if (targets_enemy.Length == 0) {
            targets_spawner = GameObject.FindGameObjectsWithTag("enemy_spawner");
            int random = Random.Range(0, targets_enemy.Length);
            transform.LookAt(targets_spawner[random].transform);
        }
        int random_number = Random.Range(0, targets_enemy.Length);
        if(targets_enemy.Length > 0)
        {
            transform.LookAt(targets_enemy[random_number].transform);
        }
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 50);
    }

    void Destroy() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy_spawner")
        {
            other.gameObject.GetComponent<enemy_spawner>().Health -= damage;
        }
        if(other.gameObject.tag == "enemy_fighter")
        {
            other.gameObject.GetComponent<enemy_fighter>().Health -= damage;
            Destroy(gameObject);
        }        
    }
}
