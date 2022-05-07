using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] nematodes = GameObject.FindGameObjectsWithTag("Nematode");
        target = nematodes[UnityEngine.Random.Range(0, nematodes.Length)];
        Invoke("KillMe", 10);
    }

    public void KillMe()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
        transform.LookAt(target.transform);

        if (transform.position == target.transform.position)
        {
            KillMe();
        }
    }
}