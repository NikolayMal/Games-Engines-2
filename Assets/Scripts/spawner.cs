using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject mothership;
    public GameObject planet;
    // Start is called before the first frame update
    void Start()
    {
        // GameObject ally_mothership = Instantiate(Resources.Load("ally_mothership"), transform.position, transform.rotation) as GameObject;
        Instantiate(mothership, transform.position, transform.rotation);
        // Instnatiate a planet 1000 units infront from the spawner
        Instantiate(planet, transform.position + transform.forward * 1000, transform.rotation);
        // Instantiate(planet, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
