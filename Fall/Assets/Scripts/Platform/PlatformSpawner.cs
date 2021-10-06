using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public GameObject normalPlatform;
    public GameObject spikedPlatform;
    public GameObject breakablePlatform;
    public GameObject monsterPlatform;
    public GameObject coinPlatform;

    //public GameObject doubleMonsterPlatform;

    //public float spawnTimer = 2f;
    public static float spawnTimer;
    float currentSpawnTimer;
    int spawnCount;
    float minX = -1f, maxX = 1f;


    // Start is called before the first frame update
    void Start()
    {
        currentSpawnTimer = spawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatforms();
    }

    void SpawnPlatforms()
    {
        currentSpawnTimer += Time.deltaTime;
        
        if(currentSpawnTimer > spawnTimer)
        {
            spawnCount++;
            Vector3 position = transform.position;
            position.x = Random.Range(minX, maxX);

            GameObject newPlatform = null;

            if (spawnCount < 2)
            {
                newPlatform = Instantiate(normalPlatform, position, Quaternion.identity);
            }         
           
            else if(spawnCount == 2)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(normalPlatform, position, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(spikedPlatform, position, Quaternion.identity);
                }               
            }
            else if (spawnCount == 3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(normalPlatform, position, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(breakablePlatform, position, Quaternion.identity);
                }

               
            }
            else if (spawnCount == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(normalPlatform, position , Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(monsterPlatform, position , Quaternion.identity);
                }

                //spawnCount = 0;
            }

            else if (spawnCount == 5)       // Code for double monster spawn 
            {
                if (Random.Range(0, 3) > 0)
                {
                    newPlatform = Instantiate(normalPlatform, position, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(coinPlatform, position, Quaternion.identity);
                }

                spawnCount = 0;
            }

            if (newPlatform)
            {
                newPlatform.transform.parent = transform;
            }
            
            currentSpawnTimer = 0; 
        }
    }
}
