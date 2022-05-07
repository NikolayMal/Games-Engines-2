using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ally_spawnership : MonoBehaviour
{
    public float speed = 50f;
    private GameObject ally_mothership;
    Vector3 targetPos;
    Vector3 worldTarget;
    Vector3 offset;

    void Start()
    {
        ally_mothership = GameObject.FindWithTag("ally_mothership");
        offset = transform.position - ally_mothership.transform.position;
        offset = Quaternion.Inverse(ally_mothership.transform.rotation) * offset;
        
        transform.parent = ally_mothership.transform;
    }

    void Update()
    {
        // Avoidance
        if (Vector3.Distance(transform.position, ally_mothership.transform.position) < 75 || Vector3.Distance(transform.position, GameObject.FindWithTag("ally_spawner").transform.position) < 30)
        {
            targetPos = ally_mothership.transform.position + offset;
            worldTarget = ally_mothership.transform.TransformPoint(offset);
            transform.position = Vector3.MoveTowards(transform.position, worldTarget, speed * Time.deltaTime); 
        }
    }
}
