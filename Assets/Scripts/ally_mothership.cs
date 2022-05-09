using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ally_mothership : MonoBehaviour
{
    public GameObject ally_spawnership;
    private GameObject target;
    public float speed = 5f;
    private int check1 = 0;
    public int Health = 10000;

    void Start()
    {
        target = GameObject.FindWithTag("Planet");

        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.transform.position = transform.position + transform.forward * 50;
        cylinder.transform.Rotate(new Vector3(0, 90, 90));
        cylinder.transform.localScale = new Vector3(10, 50, 25);
        cylinder.transform.parent = transform;
        cylinder.GetComponent<Renderer>().enabled = false;
        cylinder.tag = "ally_cylinder";

        gameObject.AddComponent<ally_mothership_move>();
    }

    void Update()
    {
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
            gameObject.GetComponent<ally_mothership_move>().enabled = false;
        }

        if (Health <= 0)
        {
            Debug.Log("Ally Spawner Destroyed!");
            Destroy(gameObject);
        }
        
    }
}
