# Games-Engines-2 : Ender's Game

Name: Nikolay Malyshev

Student Number: C18333703

Class Group: DT282/4

# Description of the project

The project is a recreation of the final battle scene in the movie 'Ender's Game'. When run, you can see the battle that occurs which leads to the eventual destruction of the enemy home's planet.

# Instructions for use

- Start the scene titled "Main"
- Press play and watch. There are no user inputs.


- If the skybox was not loaded in, it is because you do not have the asset downloaded. Retrieve the asset from:
  [asset-store](https://assetstore.unity.com/packages/3d/environments/sci-fi/real-stars-skybox-lite-116333#description).
  - Download and Import it into the Unity folder.
  - Open the StarSkybox04 folder located in "Assets/Real Stars Skybox/StarSkybox04/" and drag "Cubemap Stars" onto an empty part of the Scene.

# How it works

##  Control Script

The controller script is responsible for spawning the initial objects in all the neccessary positions. It then keeps track of what is alive and what has been killed to move to the next stage of the battle. It works with the spawner script to begin the battle.

```C#

    void Start()
    {
        Instantiate(ally_mothership, transform.position, transform.rotation);
        Instantiate(planet, transform.position + transform.forward * 1000, transform.rotation);

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(100, 100, 100);
        sphere.GetComponent<Renderer>().material.color = Color.red;
        GameObject target = GameObject.FindWithTag("Planet");
        sphere.transform.position = target.transform.position;
        sphere.transform.position = sphere.transform.position + sphere.transform.forward * -100 + sphere.transform.up * -20;
        sphere.GetComponent<Renderer>().enabled = false;
        sphere.tag = "sphere";

        Instantiate(enemy_spawnership, sphere.transform.position, sphere.transform.rotation);
        Instantiate(enemy_spawnership, sphere.transform.position + sphere.transform.right * -75, sphere.transform.rotation);
        Instantiate(enemy_spawnership, sphere.transform.position + sphere.transform.right * 75, sphere.transform.rotation);


        ally_mothership = GameObject.FindWithTag("ally_mothership");
        ally_mothership.GetComponent<ally_mothership_move>().enabled = false;
    }

```

Checking for enemy fighters, once the initial wave is destroyed move to the next stage.

```C#
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
```

Same as mentioned above, we would check and move to next stages when required. Such as moving the fighters to a circle rotation around the mothership, changing camera views, moving the mothership and creating the next wave of enemy fighters.

eg.

```C#
    void fighter_to_circle()
    {
        side_camera.SetActive(false);
        back_camera.SetActive(true);


        for(int i = 0; i < ally_fighters.Length; i++)
        {
            ally_fighters[i].GetComponent<ally_fighter>().circle();   
        }
    }
```

# List of classes/assets in the project and whether made yourself or modified or if its from a source, please give the reference

| Class/asset         | Source                                                                                               |
| ------------------- | ---------------------------------------------------------------------------------------------------- |
| ally_fighter.cs| Self  written                                                                                         |
| ally_mothership.cs          | Self written                                                                                         |
| ally_mothership_move.cs     | Self written                                                                                         |
| ally_spawnership.cs | Self written                                                                                         |
| Boid.cs      | Adapted from notes                                                                                         |
| circle_camera.cs         | Self written                                                                                         |
| Constrain.cs      | Adapted from notes                                                                                         |
| circle_mothership.cs  | Self written                                                                                         |
| controller.cs          | Self written                                                                                         |
| enemy_fighter.cs  | Self written                                                                                         |
| enemy_constrain.cs         |  Adapted from notes                                                                                         |
| enemy_spawner2.cs       | Self written                                                                                         |
| enemy_spawner.cs           | Self written                                                                                         |
| laser_ally_fighter.cs      | Self written                                                                                         |
| laser_enemy_fighter.cs      | Self written      
| laser_mothership.cs      | Self written
| laser_mothership_move.cs      | Self written     
| Noise Wander.cs      | Adapted from notes
| Obstacle Avoidance.cs      | Adapted from notes
| spawner.cs      | Self written    
| SteeringBehaviour.cs      | Self written


# Video

[Youtube](https://youtu.be/kppexxloWaw)