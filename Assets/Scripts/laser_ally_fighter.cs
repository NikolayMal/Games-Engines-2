using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_ally_fighter : MonoBehaviour
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
        if (other.gameObject.tag == "enemy_spawner")
        {
            other.gameObject.GetComponent<ally_spawnership>().Health -= damage;
        }
        if(other.gameObject.tag == "enemy_fighter")
        {
            other.gameObject.GetComponent<enemy_fighter>().Health -= damage;
            Destroy(gameObject);
        }        
    }
}
