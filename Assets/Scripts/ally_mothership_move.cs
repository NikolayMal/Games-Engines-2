using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ally_mothership_move : MonoBehaviour
{

    private GameObject target;
    public float speed = 10f;

    void Start()
    {
        target = GameObject.FindWithTag("Planet");

    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.LookAt(target.transform);
    }
}
