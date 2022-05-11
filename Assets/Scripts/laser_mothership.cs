using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_mothership : MonoBehaviour
{
    public GameObject laser;
    private GameObject planet;

    void Start()
    {
        planet = GameObject.FindWithTag("Planet");    
        laser = Instantiate(laser, transform.position + transform.forward * 50, Quaternion.Euler(90, 90, 90)) as GameObject;
    }

    void Update()
    {        

    }
}
