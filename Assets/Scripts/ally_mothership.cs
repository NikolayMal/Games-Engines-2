using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ally_mothership : MonoBehaviour
{
    public GameObject mothership;
    private GameObject target;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
        // Set target to an object with tag 'planet'
        target = GameObject.FindWithTag("Planet");
        // Debug.Log(target.transform.position);   
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards the target
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        // Rotate to face the target
        transform.LookAt(target.transform);
        
    }
}
