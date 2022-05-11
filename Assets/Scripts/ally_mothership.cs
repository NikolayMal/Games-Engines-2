using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ally_mothership : MonoBehaviour
{
    public GameObject ally_spawnership;
    private GameObject target;
    private int check1 = 0;

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
        gameObject.GetComponent<ally_mothership_move>().enabled = false;
    }

    void Update()
    {
        if( check1 == 0) {
            for (int i = 0; i < 10; i++)
            {
                Vector3 spawnPosition = new Vector3(transform.position.x + Random.Range(-100, 100), transform.position.y + Random.Range(-100, 100), transform.position.z  + Random.Range(-50, 150));
                GameObject spawnership = Instantiate(ally_spawnership, spawnPosition, transform.rotation) as GameObject;
            }
            check1 = 1;
        }
    }
}
