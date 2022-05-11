using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject[] enemy_spawner_targets1;
    public GameObject[] ally_fighters;
    public GameObject[] enemy_fighters_2;
    private GameObject[] ally_spawners_2;
    private GameObject[] enemy_spawners_2;
    private GameObject ally_mothership;
    public GameObject enemy_spawnership;
    public GameObject enemy_spawnership2;
    private GameObject planet;
    private GameObject sphere;
    private int check_for_fighter_circle = 0;
    private int stop_loop_1 = 0;
    private int stop_loop_2 = 0;
    private float distance_mothership_planet;
    

    void Start()
    {
        Invoke("delayed_start", 2.0f);
        InvokeRepeating("check_for_enemy_targets_check1", 5.0f, 5.0f);
    }

    void Update()
    {
        if(enemy_spawner_targets1.Length == 0 && stop_loop_2 == 0)
        {
            stop_loop_2 = 1;
        }
        // Stage 1 : Initial Small Fight : enemy spawns - mothership stops and we wait
        if (enemy_spawner_targets1.Length == 0 && Vector3.Distance(ally_mothership.transform.position, planet.transform.position) < 900 && stop_loop_2 == 0)
        {
            ally_mothership.GetComponent<ally_mothership_move>().enabled = true;
        }
        if (Vector3.Distance(ally_mothership.transform.position, planet.transform.position) < 900 && check_for_fighter_circle == 0)
        {
            ally_mothership.GetComponent<ally_mothership_move>().enabled = false;
        }

        // Stage 2 : Circling around the mothership and moving towards planet
        if(check_for_fighter_circle == 1 ) 
        {
            if(stop_loop_1 == 0)
            {
                Invoke("second_wave_enemy_spawn", 1.0f);
                Invoke("fighter_to_circle", 45.0f);
                Invoke("move_mothership", 60.0f);
                
                stop_loop_1 = 1;
            }
        }

        // Stage 3
        if (Vector3.Distance(ally_mothership.transform.position, planet.transform.position) < 300)
        {
            ally_mothership.GetComponent<ally_mothership_move>().enabled = false;
            ally_mothership.GetComponent<laser_mothership>().enabled = true;
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
        ally_fighters = GameObject.FindGameObjectsWithTag("ally_fighter");
        
        distance_mothership_planet = Vector3.Distance(ally_mothership.transform.position, planet.transform.position);

        if ( enemy_spawner_targets1.Length == 0)
        {
            check_for_fighter_circle = 1;
        }
    }

    void fighter_to_circle()
    {
        for(int i = 0; i < ally_fighters.Length; i++)
        {
            ally_fighters[i].GetComponent<ally_fighter>().circle();   
        }
    }

    void move_mothership() {
        ally_mothership.GetComponent<ally_mothership_move>().enabled = true;   
    }

    void second_wave_enemy_spawn() {
        Invoke("ally_spawn_2", 1.0f);

        sphere = GameObject.FindGameObjectWithTag("sphere");
        Instantiate(enemy_spawnership2, sphere.transform.position, sphere.transform.rotation);
        Instantiate(enemy_spawnership2, sphere.transform.position + sphere.transform.right * -50, sphere.transform.rotation);
        Instantiate(enemy_spawnership2, sphere.transform.position + sphere.transform.right * 50, sphere.transform.rotation);
        Instantiate(enemy_spawnership2, sphere.transform.position + sphere.transform.up * -50, sphere.transform.rotation);
        Instantiate(enemy_spawnership2, sphere.transform.position + sphere.transform.up * 50, sphere.transform.rotation);
        Instantiate(enemy_spawnership2, sphere.transform.position + sphere.transform.up * 50 + sphere.transform.right * -50, sphere.transform.rotation);
        Instantiate(enemy_spawnership2, sphere.transform.position + sphere.transform.up * 50 + sphere.transform.right * 50, sphere.transform.rotation);
        Instantiate(enemy_spawnership2, sphere.transform.position + sphere.transform.up * -50 + sphere.transform.right * -50, sphere.transform.rotation);
        Instantiate(enemy_spawnership2, sphere.transform.position + sphere.transform.up * -50 + sphere.transform.right * 50, sphere.transform.rotation);
        InvokeRepeating("check_for_spawner_2", 12.0f, 1.0f);
    }

    void check_for_spawner_2() {
        enemy_fighters_2 = GameObject.FindGameObjectsWithTag("enemy_fighter");
        for(int i = 0; i < enemy_fighters_2.Length; i++)
        {
            enemy_fighters_2[i].GetComponent<enemy_fighter>().second_wave_check_func();
        }
        
        enemy_spawners_2 = GameObject.FindGameObjectsWithTag("enemy_spawner");
        for(int i = 0; i < enemy_spawners_2.Length; i++)
        {
            enemy_spawners_2[i].GetComponent<enemy_spawner2>().count_reset();
        }

    }

    void ally_spawn_2() { 
        ally_spawners_2 = GameObject.FindGameObjectsWithTag("ally_spawner");
        for (int j = 0; j < ally_spawners_2.Length; j++)
        {
            ally_spawners_2[j].GetComponent<ally_spawnership>().spawn_again();
        }
    }
}
