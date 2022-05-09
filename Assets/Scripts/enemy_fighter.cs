using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_fighter : MonoBehaviour
{
    public GameObject[] targets;
    public int random_target;
    // Start is called before the first frame update
    void Start()
    {  
       InvokeRepeating("find_targets", 1.0f, 20.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (targets.Length > 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 10);
        }
    }

    void find_targets()
    {
        // find all targets with tag enemy_spawner

        targets = GameObject.FindGameObjectsWithTag("ally_spawner");
        // if targets.leength is null

        if (targets.Length == 0) {
            targets = GameObject.FindGameObjectsWithTag("ally_fighter");
        }
        int random_target = Random.Range(0, targets.Length - 1);
        Debug.Log(random_target);
        transform.LookAt(targets[random_target].transform);
    }
}
