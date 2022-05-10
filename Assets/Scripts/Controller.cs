using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private GameObject[] enemy_spawner_targets1;
    private GameObject[] ally_fighters;
    private GameObject ally_mothership;
    private GameObject planet;
    private int check_for_fighter_circle = 0;

    void Start()
    {
        Invoke("delayed_start", 2.0f);
        InvokeRepeating("check_for_enemy_targets_check1", 5.0f, 5.0f);
    }

    void Update()
    {
        // Stage 1 : Initial Small Fight
        if (enemy_spawner_targets1.Length == 0)
        {
            ally_mothership.GetComponent<ally_mothership_move>().enabled = true;
            if(check_for_fighter_circle == 0)
            {
                for(int i = 0; i < ally_fighters.Length; i++)
                {
                    // ally_fighters[i].GetComponent<ally_fighter>().circle();

                    ally_fighters[i].GetComponent<Boid>().enabled = false;
                    ally_fighters[i].AddComponent<circle_mothership>();
                
                }
                
                check_for_fighter_circle = 1;
            }
        }
        if (Vector3.Distance(ally_mothership.transform.position, planet.transform.position) < 900 && check_for_fighter_circle == 0 || check_for_fighter_circle == 1)
        {
            ally_mothership.GetComponent<ally_mothership_move>().enabled = false;
        }

        // Stage 2 : Circling around the mothership and moving towards planet
        if(check_for_fighter_circle == 1) {
            Debug.Log("Ready to go to next stage");
        }

    }

    void delayed_start()
    {
        enemy_spawner_targets1 = GameObject.FindGameObjectsWithTag("enemy_spawner");

        ally_mothership = GameObject.FindGameObjectWithTag("ally_mothership");
        ally_mothership.GetComponent<ally_mothership_move>().enabled = true;

        ally_fighters = GameObject.FindGameObjectsWithTag("ally_fighter");

        planet = GameObject.FindGameObjectWithTag("Planet");


    }

    void check_for_enemy_targets_check1()
    {
        enemy_spawner_targets1 = GameObject.FindGameObjectsWithTag("enemy_spawner");
    }
}
