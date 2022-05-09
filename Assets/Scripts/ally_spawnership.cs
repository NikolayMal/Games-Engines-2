using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ally_spawnership : MonoBehaviour
{
    public float speed = 50f;
    private float distance;
    private GameObject ally_mothership;
    public GameObject ally_fighter;
    Vector3 worldTarget;
    Vector3 offset;
    public int Health = 100;


    // private IEnumerator coroutine;

    public void OnEnable() {
        InvokeRepeating("Fighter", 2.0f, 1.0f);
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
        // Avoid ally mothership
        if (Vector3.Distance(transform.position, ally_mothership.transform.position) < 50)
        {
            Debug.Log("Moving away from mothership");
            worldTarget = ally_mothership.transform.TransformPoint(offset);
            transform.position = Vector3.MoveTowards(transform.position, worldTarget, speed * Time.deltaTime);
        }
        
        if (Health == 0)
        {
            Debug.Log("Ally Spawner Destroyed!");
            Destroy(gameObject);
        }
    }

    void Fighter()
    {
        // Count all objects with tag "ally_fighter"
        // int count = GameObject.FindGameObjectsWithTag("ally_fighter").Length;
        // Count children of ally_spawnership
        int count = transform.childCount;
        if(count < 30) {
            // Spawn fighter under the ally_spawnership
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y - 20, transform.position.z);
            // Quaternion spawnRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            GameObject fighter = Instantiate(ally_fighter, spawnPosition, Quaternion.identity) as GameObject;
            fighter.transform.parent = transform;
            fighter.AddComponent<NoiseWander>().axis = NoiseWander.Axis.Vertical;
            fighter.AddComponent<NoiseWander>().axis = NoiseWander.Axis.Horizontal;
            fighter.AddComponent<ObstacleAvoidance>();
            fighter.AddComponent<Constrain>();
        }
    }

}
