using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_mothership_move : MonoBehaviour
{
    private GameObject planet;
    public GameObject explosion;
    void Start()
    {
        planet = GameObject.FindWithTag("the_planet");
        explosion = Resources.Load("Explosion2") as GameObject;
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 50);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "the_planet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }
}
