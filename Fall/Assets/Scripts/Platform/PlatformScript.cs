using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float movesSpeed = 2;
    public float DestroyPos = 6;
    public bool isPlatform, isSpike, isBreakable;
    public GameObject warning; 
    GameObject warningSign;
    Animator anim;
    BGScroll bGScroll; 

    Collider2D platformCollider; 

    bool isGrounded; 

    // Start is called before the first frame update
    void Start()
    {
        bGScroll = GetComponent<BGScroll>();
        if(isBreakable)
        {
           anim = GetComponent<Animator>();
           platformCollider = GetComponent<Collider2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();     
        if(GameManager.instance.score < 300)
        {
            PlatformSpawner.spawnTimer = 2.2f;
            movesSpeed = 1f;           
        }
        else if (GameManager.instance.score > 300 && GameManager.instance.score < 600)
        {
            PlatformSpawner.spawnTimer = 1.9f;
            movesSpeed = 1.5f;     
        }
        else if (GameManager.instance.score > 600 && GameManager.instance.score < 900)
        {
            PlatformSpawner.spawnTimer = 1.5f;
            movesSpeed = 2f;         
        }
        else if (GameManager.instance.score > 900 && GameManager.instance.score < 1200)
        {
            PlatformSpawner.spawnTimer = 1.1f;
            movesSpeed = 2.5f;          
        }
        else if(GameManager.instance.score > 1200 && GameManager.instance.score < 1500)
        {
            PlatformSpawner.spawnTimer = 1.1f;
            movesSpeed = 3f;
        }
        else if (GameManager.instance.score > 1500)
        {
            PlatformSpawner.spawnTimer = 0.8f;
            movesSpeed = 3.5f;
        }
    }

    private void Move()
    {
        Vector2 position = transform.position;
        position.y += movesSpeed * Time.deltaTime;
        transform.position = position;


        if(position.y > DestroyPos)
        {
            Destroy(this.gameObject);
        }
    }

    void DestroyBreakable()
    {        
        Invoke("DestroyGO", 0.3f);
    }

    void DestroyGO()
    {
        //soundManager .instance.iceBreakSound
        Destroy(this.gameObject);
    }

    void TurnOffCollider()
    {
        platformCollider.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {            
            if(isBreakable)
            {
                // Warning Signal spawn
                warningSign = Instantiate(warning, new Vector3(gameObject.transform.position.x,gameObject.transform.position.y + 3,gameObject.transform.position.z), Quaternion.identity);
                warningSign.transform.SetParent(gameObject.transform); 
                StartCoroutine(WarningWaitTime());             

            }
            if(isPlatform)
            {
                // SoundManager
            }     

        }
    }


    IEnumerator WarningWaitTime()
    {
        yield return new WaitForSeconds(0.3f); 
        Destroy(warningSign);
        anim.SetTrigger("CollisionWithPlayer");
    }
}
