using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_enemy_fighter : MonoBehaviour
{
    private int damage = 10;

    void Start()
    {
        Invoke("Destroy", 7.0f);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 100);
    }

    void Destroy() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ally_spawner")
        {
            other.gameObject.GetComponent<ally_spawnership>().Health -= damage;
        }
        if (other.gameObject.tag == "ally_fighter")
        {
            other.gameObject.GetComponent<ally_fighter>().Health -= damage;
        }
        Destroy(gameObject);
    }
}
