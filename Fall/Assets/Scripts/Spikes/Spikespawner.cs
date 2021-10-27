using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikespawner : MonoBehaviour
{
    public GameObject icicle;
    public GameObject fallWarning;
    GameObject warning;

    float minX = 2.65f, maxX = 7.2f, minY = -5f;
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
                    SoundManager.instance.IceBreakClip();
                    warning = Instantiate(fallWarning, position, Quaternion.identity);
                    warning.transform.localScale = new Vector3(0.05f, 0.05f, 0.1f);
                    StartCoroutine(DestroyWarning());
                    StartCoroutine(SpawnDelay());
                    spawnCount = 0;
                }

                if (position.y < minY)
                {
                    Destroy(this.gameObject);
                }

                currentSpawnTimer = 0;

                IEnumerator SpawnDelay()
                {
                    yield return new WaitForSeconds(1);                    
                    newPlatform = Instantiate(icicle, position, Quaternion.identity);
                }

                IEnumerator DestroyWarning()
                {
                    yield return new WaitForSeconds(1);
                    Destroy(warning);
                }

            }            

        }
    }

}
