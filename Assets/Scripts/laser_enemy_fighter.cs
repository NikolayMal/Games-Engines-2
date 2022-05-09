using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_enemy_fighter : MonoBehaviour
{
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
        Debug.Log("Hit something...");
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "ally_fighter")
        {
            Debug.Log("hit ally spawner");
            Destroy(gameObject);
        }
    }
}
