using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ally_mothership : MonoBehaviour
{
    public GameObject ally_spawnership;
    private GameObject target;
    public float speed = 5f;
    private int check1 = 0;

    void Start()
    {
        target = GameObject.FindWithTag("Planet");
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.LookAt(target.transform);

        if (Vector3.Distance(transform.position, target.transform.position) < 900)
        {
            if( check1 == 0) {
                for (int i = 0; i < 10; i++)
                {
                    Vector3 spawnPosition = new Vector3(transform.position.x + Random.Range(-100, 100), transform.position.y + Random.Range(-100, 100), transform.position.z);
                    // Quaternion spawnRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                    GameObject spawnership = Instantiate(ally_spawnership, spawnPosition, transform.rotation) as GameObject;
                }
                check1 = 1;
            }
            
            // Stop the movement of the mothership
            speed = 0;
        }
        
    }
}
