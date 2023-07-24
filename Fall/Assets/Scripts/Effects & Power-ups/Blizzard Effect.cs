using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BlizzardEffect : MonoBehaviour
{
    
    public Volume volume; 
    DepthOfField dof;

    public bool blizzard;


    float spawnTimer = 10f;
    public float currentSpawnTimer;
    int spawnCount;

    void Awake()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGet(out dof);
        currentSpawnTimer = spawnTimer;
    }

    void Update()
    {
        Blizzard(); 

        if(GameManager.instance.gameOver)
        {
            currentSpawnTimer = spawnTimer;
        }

        if(GameManager.instance.score > 1000)
        {
            currentSpawnTimer -= 1 * Time.deltaTime;


            if(currentSpawnTimer <= 0)
            {        
                    blizzard = true; 
                    StartCoroutine(WaitThreeSeconds());            
            }  
            else
            {
                    blizzard = false; 
            }
       
        }

       
    }

    void Blizzard()
    {
        if(blizzard)
        {
            Debug.Log("Blizzard");
            dof.focalLength.value = 300;
        }
        else 
        {
            dof.focalLength.value = 1;
        }
    }
    

    IEnumerator WaitThreeSeconds()
    {
        yield return new WaitForSeconds(7);
        currentSpawnTimer = spawnTimer; 
    }
}
