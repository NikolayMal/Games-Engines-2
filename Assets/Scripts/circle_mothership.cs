using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle_mothership : MonoBehaviour
{
    private GameObject ally_mothership;
    private GameObject ally_cylinder;
    private GameObject planet;

    Vector3 circlePosition;

    // Start is called before the first frame update
    void Start()
    {
        // Get mothership
        ally_mothership = GameObject.FindWithTag("ally_mothership");
        ally_cylinder = GameObject.FindWithTag("ally_cylinder");
        planet = GameObject.FindWithTag("Planet");
        
        // look at planet
        transform.LookAt(planet.transform);


        // cylinder.tag = "ally_mothership_circle";
        
        
        Invoke("to_location", 1.0f);


    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, ally_cylinder.transform.position) > 40)
        {
            transform.position = Vector3.MoveTowards(transform.position, circlePosition, Time.deltaTime * 100);
        }

        if (Vector3.Distance(transform.position, ally_cylinder.transform.position) < 40)
        {
            transform.RotateAround(ally_mothership.transform.position, Vector3.forward, Time.deltaTime * 100);
        }


        
    }

    void to_location() {
        circlePosition = new Vector3(ally_cylinder.transform.position.x , ally_cylinder.transform.position.y, ally_cylinder.transform.position.z + Random.Range(-50, 50));
    }
}
