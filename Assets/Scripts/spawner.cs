using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject ally_mothership;
    public GameObject planet;
    public GameObject enemy_spawnership;
    
    void Start()
    {
        Instantiate(ally_mothership, transform.position, transform.rotation);
        Instantiate(planet, transform.position + transform.forward * 1000, transform.rotation);

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(100, 100, 100);
        sphere.GetComponent<Renderer>().material.color = Color.red;
        GameObject target = GameObject.FindWithTag("Planet");
        sphere.transform.position = target.transform.position;
        sphere.transform.position = sphere.transform.position + sphere.transform.forward * -100 + sphere.transform.up * -20;
        sphere.GetComponent<Renderer>().enabled = false;

        Instantiate(enemy_spawnership, sphere.transform.position, sphere.transform.rotation);
        // Instantiate(enemy_spawnership, sphere.transform.position + sphere.transform.right * -75, sphere.transform.rotation);
        // Instantiate(enemy_spawnership, sphere.transform.position + sphere.transform.right * 75, sphere.transform.rotation);


        // enable controller script
        ally_mothership = GameObject.FindWithTag("ally_mothership");
        ally_mothership.GetComponent<ally_mothership_move>().enabled = false;
        
        
    }

    void Update()
    {        
        
    }
}
