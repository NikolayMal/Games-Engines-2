using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle_mothership : MonoBehaviour
{
    private GameObject ally_mothership;
    private GameObject ally_cylinder;
    private GameObject planet;

    Vector3 circlePosition;

    void Start()
    {
        ally_mothership = GameObject.FindWithTag("ally_mothership");
        ally_cylinder = GameObject.FindWithTag("ally_cylinder");
        planet = GameObject.FindWithTag("Planet");
        
        transform.LookAt(planet.transform);

        Invoke("to_location", 0.0f);
    }

    void Update()
    {

        if (Vector3.Distance(transform.position, ally_cylinder.transform.position) > 50)
        {
            transform.position = Vector3.MoveTowards(transform.position, circlePosition, Time.deltaTime * 15);
        }

        if (Vector3.Distance(transform.position, ally_cylinder.transform.position) < 50)
        {
            transform.RotateAround(ally_mothership.transform.position, Vector3.forward, Time.deltaTime * 15);
        }
    }

    void to_location() {
        circlePosition = new Vector3(ally_cylinder.transform.position.x , ally_cylinder.transform.position.y, ally_cylinder.transform.position.z + Random.Range(-30, 60));        
    }
}
