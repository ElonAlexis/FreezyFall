using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPSpawner : MonoBehaviour
{
    public GameObject[] PowerUps; 
    int currentPowerUp;
    float minX = -2, maxX = 2, maxY = 5f;

    public float spawnTimer = 2f;
    float currentSpawnTimer;
    int spawnCount = 0;

    // Start is called before the first frame update
    void Start()
    {
         currentSpawnTimer = spawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        PowerUp();
    }

    void PowerUp()
    {   
         currentSpawnTimer += Time.deltaTime;
        if (currentSpawnTimer > spawnTimer)
        {
            spawnCount++;
            Vector2 position = new Vector2(Random.Range(minX,maxX),maxY);
            currentPowerUp = Random.Range(0, PowerUps.Length); 
            if(spawnCount == 15)
            {
                Instantiate(PowerUps[currentPowerUp], position, Quaternion.identity);
                spawnCount = 0;
            }   
             currentSpawnTimer = 0;    
        }
    }
}
