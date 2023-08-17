using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class BlizzardEffect : MonoBehaviour
{
    
    public Volume volume; 
    public DepthOfField dof;

    bool blizzard;
    [SerializeField]
    GameObject blizzardEffect;
    SpriteRenderer blizzardSpriteRenderer; 
    Color blizzardColor;
    [SerializeField]
    GameObject normalSnow; 
    [SerializeField]
    GameObject blizzardL; 
    [SerializeField]
    GameObject blizzardR; 
    int rightOrLeft;

bool blizzardSnowActivated = false;

    float spawnTimer = 10f;
    public float currentSpawnTimer;
    int spawnCount;

    void Awake()
    {
        blizzardSpriteRenderer = blizzardEffect.GetComponent<SpriteRenderer>(); 
        blizzardColor = blizzardSpriteRenderer.color;       
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

    if (GameManager.instance.gameOver)
    {
        currentSpawnTimer = spawnTimer;
    }

    if (GameManager.instance.score > 10)
    {
        currentSpawnTimer -= 1 * Time.deltaTime;

        if (currentSpawnTimer <= 0)
        {
            if (!blizzardSnowActivated)
            {
                blizzard = true;
                ActivateBlizzardSnow(); // Call the function to activate blizzard snow
                blizzardSnowActivated = true; // Set the flag to true
                StartCoroutine(WaitThreeSeconds());
                
            }
        }
        else
        {
            blizzard = false;
            
        }
    }
}

    void Blizzard()
    {
        if (blizzard)
        {           
            dof.focalLength.value = dof.focalLength.value += 20f * Time.deltaTime;      // Blur effect on 
            if(blizzardColor.a != 1)
            {
                blizzardColor.a = blizzardColor.a += 0.4f * Time.deltaTime; // Set alpha to make it fully opaque
                blizzardSpriteRenderer.color = blizzardColor; // Apply the color change to the SpriteRenderer
                if(blizzardColor.a >= 1)
                {
                    blizzardColor.a = 1;
                }
                if(dof.focalLength.value >= 300)
                {
                   dof.focalLength.value = 300;
                }
            }         
        }
        else
        {
            
            dof.focalLength.value = dof.focalLength.value -= 50f * Time.deltaTime;        // Blur effect off 
            blizzardColor.a -= 0.4f * Time.deltaTime; // Set alpha to make it fully transparent
            blizzardSpriteRenderer.color = blizzardColor; // Apply the color change to the SpriteRenderer
            blizzardSnowActivated = false; // Reset the flag when not in blizzard mode
            if(blizzardColor.a <= 0.2f)         // adding a buffer for when snow should change (just before blizzard finishes) 
            {
                normalSnow.SetActive(true);
                blizzardL.SetActive(false);
                blizzardR.SetActive(false);
            }
            
            if(blizzardColor.a <= 0)
            {                
                blizzardColor.a = 0;
            }
            if(dof.focalLength.value <= 0)
            {
                dof.focalLength.value = 0;
            }
        }
       
    }
    

    IEnumerator WaitThreeSeconds()
    {
        yield return new WaitForSeconds(7);
        currentSpawnTimer = spawnTimer; 
    }

    void ActivateBlizzardSnow()
    {
        rightOrLeft = Random.Range(0,2);
        Debug.Log("Right / Left Value" + rightOrLeft);

        if(rightOrLeft == 0)
        {
            normalSnow.SetActive(false);
            blizzardL.SetActive(true);
        }
        else
        {
            normalSnow.SetActive(false);
            blizzardR.SetActive(true);
        }
    }
}
