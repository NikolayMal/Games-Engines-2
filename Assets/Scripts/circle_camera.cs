using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle_camera : MonoBehaviour
{
    private GameObject mothership;
    // Start is called before the first frame update
    void Start()
    {
        mothership = GameObject.FindWithTag("ally_mothership");    
    }

    // Update is called once per frame
    void Update()
    {
        // circle around the mothership at a distance of 50
        transform.RotateAround(mothership.transform.position, Vector3.forward, Time.deltaTime * 15);
    }
}
