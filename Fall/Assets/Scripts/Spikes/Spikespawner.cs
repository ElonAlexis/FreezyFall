using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikespawner : MonoBehaviour
{
    public GameObject icicle;
    float minX = -2, maxX = 2, minY = -5f;
    public float spawnTimer = 2f;
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
        SpawnSpike();
    }

    void SpawnSpike()
    {
        currentSpawnTimer += Time.deltaTime;

        if(GameManager.instance.score > 200)
        {
            if (currentSpawnTimer > spawnTimer)
            {
                spawnCount++;
                Vector3 position = transform.position;
                position.x = Random.Range(minX, maxX);
                position.y = 4f;
                position.z = 0f;

                GameObject newPlatform = null;

                if (spawnCount == 4)
                {
                    newPlatform = Instantiate(icicle, position, Quaternion.identity);
                    spawnCount = 0;
                }

                if (position.y < minY)
                {
                    Destroy(this.gameObject);
                }

                currentSpawnTimer = 0;
            }


        }



    }




}
