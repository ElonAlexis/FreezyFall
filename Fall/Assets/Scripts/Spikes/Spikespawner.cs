﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikespawner : MonoBehaviour
{
    public GameObject icicle;
    public GameObject fallWarning;
    GameObject warning;

    Earthquake eq;

    float minY = -5f;
    public float spawnTimer = 2f;
    float currentSpawnTimer;
    int spawnCount;

    // Start is called before the first frame update
    void Start()
    {
        eq = FindObjectOfType<Earthquake>();
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
                // Get the screen boundaries
                float screenWidth = Screen.width;
                float leftBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
                float rightBoundary = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, 0, 0)).x;
                float offset = 1f;
                position.x = Random.Range(leftBoundary + offset, rightBoundary - offset);
                position.y = 4f;
                position.z = 0f;

                GameObject newPlatform = null;

                if (spawnCount == 7)
                {
                    eq.shake = true;
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
