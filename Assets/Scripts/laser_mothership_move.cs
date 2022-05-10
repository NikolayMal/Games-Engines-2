using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_mothership_move : MonoBehaviour
{
    private GameObject planet;
    // Start is called before the first frame update
    void Start()
    {
        planet = GameObject.FindWithTag("the_planet");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 100);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "the_planet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
