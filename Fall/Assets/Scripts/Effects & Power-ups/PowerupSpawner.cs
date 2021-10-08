using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    int[] powerupValue = { 1, 2, 3 };
    [SerializeField]
    GameObject spawnPoint;
    [SerializeField]
    GameObject invinciblePowerup;
    [SerializeField]
    GameObject smallPowerup;
    [SerializeField]
    GameObject slowmoPowerup; 

    void Start()
    {
        int randPowerup = Random.Range(powerupValue[0], powerupValue.Length + 1);

        if(randPowerup == 1)
        {
            GameObject invi = Instantiate(invinciblePowerup, spawnPoint.transform.position, Quaternion.identity);
            invi.transform.SetParent(spawnPoint.transform);
            Debug.Log("Powerup 1");
        }
        else if (randPowerup == 2)
        {
            GameObject small = Instantiate(smallPowerup, spawnPoint.transform.position, Quaternion.identity);
            small.transform.SetParent(spawnPoint.transform);
            Debug.Log("Powerup 2");
        }
        else if (randPowerup == 3)
        {
            GameObject slow = Instantiate(slowmoPowerup, spawnPoint.transform.position, Quaternion.identity);
            slow.transform.SetParent(spawnPoint.transform);
            Debug.Log("Powerup 3");
        }
    }

    
}
