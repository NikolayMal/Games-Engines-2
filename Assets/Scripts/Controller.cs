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
    private int stop_loop_3 = 0;
    private float distance_mothership_planet;
    private GameObject main_camera;
    private GameObject ship_camera;
    private GameObject side_camera;
    private GameObject swarm_camera;
    private GameObject back_camera;
    private GameObject circle_camera;
    private GameObject top_camera;  

    void Start()
    {
        Invoke("delayed_start", 2.0f);
        InvokeRepeating("check_for_enemy_targets_check1", 5.0f, 5.0f);


        main_camera = GameObject.FindGameObjectWithTag("MainCamera");
        ship_camera = GameObject.FindGameObjectWithTag("ShipCamera");
        side_camera = GameObject.FindGameObjectWithTag("SideCamera");
        swarm_camera = GameObject.FindGameObjectWithTag("SwarmCamera");
        back_camera = GameObject.FindGameObjectWithTag("BackCamera");
        circle_camera = GameObject.FindGameObjectWithTag("CircleCamera");
        top_camera = GameObject.FindGameObjectWithTag("TopCamera");

        main_camera.SetActive(false);
        ship_camera.SetActive(false);
        side_camera.SetActive(false);
        swarm_camera.SetActive(false);
        back_camera.SetActive(true);
        circle_camera.SetActive(false);
        top_camera.SetActive(false);
    }

    void Update()
    {
        if(enemy_spawner_targets1.Length == 0 && stop_loop_2 == 0)
        {
            stop_loop_2 = 1;
        }
        if (enemy_spawner_targets1.Length == 0 && Vector3.Distance(ally_mothership.transform.position, planet.transform.position) < 900 && stop_loop_2 == 0)
        {
            ally_mothership.GetComponent<ally_mothership_move>().enabled = true;
        }
        if (Vector3.Distance(ally_mothership.transform.position, planet.transform.position) < 900 && check_for_fighter_circle == 0)
        {
            ally_mothership.GetComponent<ally_mothership_move>().enabled = false;
            
            if(stop_loop_3 == 0){
                back_camera.SetActive(false);
                side_camera.SetActive(true);

                Debug.Log("top camera on 1 ");

                Invoke("top_camera_on_1", 6.0f);

                stop_loop_3 = 1;
            }
        }

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
        side_camera.SetActive(false);
        back_camera.SetActive(true);


        for(int i = 0; i < ally_fighters.Length; i++)
        {
            ally_fighters[i].GetComponent<ally_fighter>().circle();   
        }

    }

    void move_mothership() {
        ally_mothership.GetComponent<ally_mothership_move>().enabled = true;   

        Invoke("ship_camera_on_1", 8.0f);
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

        Invoke("swarm_camera_on_1", 8.0f);

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

    void top_camera_on_1() {
        top_camera.SetActive(true);
        side_camera.SetActive(false);

        Invoke("side_camera_on_1", 8.0f);
    }

    void side_camera_on_1() {
        side_camera.SetActive(true);
        top_camera.SetActive(false);

        Invoke("top_camera_on_2",  8.0f);
    }

    void top_camera_on_2() {
        top_camera.SetActive(true);
        side_camera.SetActive(false);
    }

    void swarm_camera_on_1() {
        swarm_camera.SetActive(true);
        side_camera.SetActive(false);
        top_camera.SetActive(false);

        Invoke("side_camera_on_2", 13.0f);
    }

    void side_camera_on_2() {
        side_camera.SetActive(true);
        swarm_camera.SetActive(false);
    }

    void ship_camera_on_1() {
        ship_camera.SetActive(true);
        back_camera.SetActive(false);

        Invoke("main_camera_on_1", 5.0f);
    }

    void main_camera_on_1() {
        main_camera.SetActive(true);
        ship_camera.SetActive(false);

        Invoke("ship_camera_on_2", 6.0f);
    }

    void ship_camera_on_2() {
        ship_camera.SetActive(true);
        main_camera.SetActive(false);
    }
}
