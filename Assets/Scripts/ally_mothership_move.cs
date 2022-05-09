using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ally_mothership_move : MonoBehaviour
{

    private GameObject target;
    public float speed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Planet");

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.LookAt(target.transform);
    }
}
