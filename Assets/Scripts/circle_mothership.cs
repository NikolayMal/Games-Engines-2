using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle_mothership : MonoBehaviour
{
    private GameObject ally_mothership;
    private GameObject ally_cylinder;
    private GameObject planet;

    Vector3 circlePosition;
    private int check1 = 0;

    // Start is called before the first frame update
    void Start()
    {
        ally_mothership = GameObject.FindWithTag("ally_mothership");
        ally_cylinder = GameObject.FindWithTag("ally_cylinder");
        planet = GameObject.FindWithTag("Planet");
        
        transform.LookAt(planet.transform);

        Invoke("to_location", 0.0f);
        Invoke("temp", 10.0f);
    }

    void Update()
    {

        if (Vector3.Distance(transform.position, ally_cylinder.transform.position) > 50 && check1 == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, circlePosition, Time.deltaTime * 100);
        }

        if (Vector3.Distance(transform.position, ally_cylinder.transform.position) < 50 && check1 == 0)
        {
            transform.RotateAround(ally_mothership.transform.position, Vector3.forward, Time.deltaTime * 100);
        }

        if(check1 == 1) {
            transform.position = Vector3.MoveTowards(transform.position, planet.transform.position, Time.deltaTime * 100);
        }
    }

    void to_location() {
        circlePosition = new Vector3(ally_cylinder.transform.position.x , ally_cylinder.transform.position.y, ally_cylinder.transform.position.z + Random.Range(-40, 60));        
    }

    void temp() {
        check1 = 1;
    }
}
