using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle_camera : MonoBehaviour
{
    private GameObject mothership;
    
    void Start()
    {
        mothership = GameObject.FindWithTag("ally_mothership");    
    }

    void Update()
    {
        transform.RotateAround(mothership.transform.position, Vector3.forward, Time.deltaTime * 15);
    }
}
