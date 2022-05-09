using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_enemy_fighter : MonoBehaviour
{
    private int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 100);
    }

    void Destroy() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit something..." + other.gameObject.tag);
        if (other.gameObject.tag == "ally_spawner")
        {
            Debug.Log("hit ally spawner");
            other.gameObject.GetComponent<ally_spawnership>().Health -= damage;
        }
        if ( other.gameObject.tag == "ally_cylinder")
        {
            Debug.Log("hit ally mothership");
            other.gameObject.GetComponent<ally_mothership>().Health -= damage;            
        }
        if (other.gameObject.tag == "ally_fighter")
        {
            Debug.Log("hit ally fighter");
            other.gameObject.GetComponent<ally_fighter>().Health -= damage;
        }
        if(other.gameObject.tag == "enemy_fighter")
        {
            Debug.Log("friendly fire!");
            other.gameObject.GetComponent<enemy_fighter>().Health -= damage;
        }


    Destroy(gameObject);
    }
}
