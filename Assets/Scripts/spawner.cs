using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject ally_mothership;
    public GameObject planet;
    
    void Start()
    {
        Instantiate(ally_mothership, transform.position, transform.rotation);
        Instantiate(planet, transform.position + transform.forward * 1000, transform.rotation);
    }

    void Update()
    {        
        
    }
}
