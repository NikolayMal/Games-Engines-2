using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nematode : MonoBehaviour
{
    public int length;

    public Material material;   

    public GameObject Target;
    public GameObject Bullet;

    void Awake()
    {
        // length = Random.Range(5, 30);
        length = 20;
        // Put your code here!
        
        for (int i = 0; i < length; i++) {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = transform.position - transform.forward * i;
            sphere.transform.parent = transform;
            sphere.GetComponent<Renderer>().material.color = Color.HSVToRGB(i / (float)length, 1, 1);

            if (i == 0) {
                sphere.AddComponent<NoiseWander>();
                sphere.AddComponent<NoiseWanderV>();
                sphere.AddComponent<ObstacleAvoidance>();
                sphere.AddComponent<Constrain>();
                // Add tag "Nematode" to the first sphere
                sphere.tag = "Nematode";
                
            }
            
            // sphere.transform.localScale = Vector3.one * (length - i) / length;

            if (i < length / 2) {
                sphere.transform.localScale = Vector3.one * (i + 1) / length;
            }

            if (i > length / 2) {
                sphere.transform.localScale = Vector3.one * (length - i) / length;  
            }        

            if ( i == length / 2)
            {
                sphere.transform.localScale = Vector3.one * ( i + 1) / length;
            }   
            
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {                       

    }

    IEnumerator Shoot(){

        
        GameObject bullet  = Instantiate(Bullet , transform.position, Quaternion.identity) as GameObject;
        bullet.transform.parent = transform;
        yield return new WaitForSeconds(5);
    }

}

