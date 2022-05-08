using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle_mothership : MonoBehaviour
{
    private GameObject ally_mothership;

    // Start is called before the first frame update
    void Start()
    {
        // Get mothership
        ally_mothership = GameObject.FindWithTag("ally_mothership");
        // Get target

    }

    // Update is called once per frame
    void Update()
    {
        // Rotate around mothership vertically
        // transform.RotateAround(ally_mothership.transform.position, Vector3.up, Time.deltaTime * 100);
        // Rotate around mothership horizontally
        transform.RotateAround(ally_mothership.transform.position, Vector3.forward, Time.deltaTime * 100);
        // transform.RotateAround(ally_mothership.transform.position, Vector3.up, 10 * Time.deltaTime);
        
    }
}
