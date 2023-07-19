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
    public GameObject powerupPlatform;
    

    //public float spawnTimer = 2f;
    public static float spawnTimer;
    float currentSpawnTimer;
    int spawnCount;
   

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
             // Get the screen boundaries
            float screenWidth = Screen.width;
            float leftBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
            float rightBoundary = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, 0, 0)).x;
            float offset = 1f;
            position.x = Random.Range(leftBoundary + offset, rightBoundary - offset);

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
            }
            else if (spawnCount == 5)       // Code for coin spawn 
            {
                if (Random.Range(0, 3) > 0)
                {
                    newPlatform = Instantiate(normalPlatform, position, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(coinPlatform, position, Quaternion.identity);
                }
            }
            else if (spawnCount == 6)       // Code for power-up platform 
            {
                if (Random.Range(0, 7) > 0)
                {
                    newPlatform = Instantiate(normalPlatform, position, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(powerupPlatform, position, Quaternion.identity);
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
