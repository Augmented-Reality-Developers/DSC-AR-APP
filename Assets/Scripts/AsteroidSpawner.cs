using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    // needed for spawning
    [SerializeField]
    GameObject prefabAsteroid1;
    [SerializeField]
    GameObject prefabAsteroid2;
    [SerializeField]
    GameObject prefabAsteroid3;


    // spawn control
    const float MinSpawnDelay = 1;
    const float MaxSpawnDelay = 2;
    Timer spawnTimer;

    

    // Start is called before the first frame update
    void Start()
    {
        

        // create and start timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
        spawnTimer.Run();

    }

    // Update is called once per frame
    void Update()
    {
        //If no of rocks in scene is less than 3 and timer has finished then spawn a new rock
        GameObject[] noOfRocks = GameObject.FindGameObjectsWithTag("Asteroid");

        if(noOfRocks.Length<3 &&spawnTimer.Finished)
        {
            SpawnRock();
        }


    }

    void SpawnAsteroid2()
    {
        float x = Random.Range(-28.5f, 32.6f);   //For spawning the enemy ships at random places between the specified range
        float y = Random.Range(8f, -8f);
        float z = Random.Range(-17.35f, -6f);

        Instantiate(Resources.Load("Asteroid 2", typeof(GameObject)), new Vector3(x, y, z), Quaternion.identity);
    }

    void SpawnAsteroid1()
    {
        float x = Random.Range(-28.5f, 32.6f);   //For spawning the enemy ships at random places between the specified range
        float y = Random.Range(8f, -8f);
        float z = Random.Range(-17.35f, -6f);

        Instantiate(Resources.Load("Asteroid 1", typeof(GameObject)), new Vector3(x, y, z), Quaternion.identity);
    }

    void SpawnAsteroid3()
    {
        float x = Random.Range(-28.5f, 32.6f);   //For spawning the enemy ships at random places between the specified range
        float y = Random.Range(8f, -8f);
        float z = Random.Range(-17.35f, -6f);

        Instantiate(Resources.Load("Asteroid 3", typeof(GameObject)), new Vector3(x, y, z), Quaternion.identity);
        
    }

    void SpawnRock()
    {
        

        // spawn random prefab
        int prefabNumber = Random.Range(0, 3);        
        if (prefabNumber == 0)
        {
            SpawnAsteroid1();          
        }
        else if (prefabNumber == 1)
        {
            SpawnAsteroid2();
        }
        else
        {
            SpawnAsteroid3();
        }
    }
}
