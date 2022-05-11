using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_mothership : MonoBehaviour
{
    public GameObject laser;
    private GameObject planet;

    // Start is called before the first frame update
    void Start()
    {
        planet = GameObject.FindWithTag("Planet");    
        laser = Instantiate(laser, transform.position + transform.forward * 50, Quaternion.Euler(90, 90, 90)) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {        

    }
}
