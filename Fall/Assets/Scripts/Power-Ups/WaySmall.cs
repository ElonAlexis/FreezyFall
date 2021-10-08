using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaySmall : MonoBehaviour
{
    PlayerScript playerScript; 
    Rigidbody2D rb;
    GameObject player;
    GameObject skin;
    Animator anim; 

    bool isSmall = false; 

    void Start()
    {
        player = GameObject.Find("Player");
        anim = player.GetComponent<Animator>();
    }
    void Update()
    {
        if(isSmall)
        {
            StartCoroutine(Timer());
        }
    }
     void OnCollisionEnter2D(Collision2D other)
    {
         if(other.gameObject.tag == "Player")
        {
            gameObject.transform.parent = null;
            isSmall = true;
            if(isSmall)
            {
                other.gameObject.transform.localScale = new Vector3 (0.3f,0.3f,0.3f);
            }           
            rb = other.gameObject.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0.2f;
            playerScript  = other.gameObject.GetComponent<PlayerScript>();
            playerScript.moveSpeed += 1;
            gameObject.transform.position = new Vector3(5,5,5);

            
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3);
        // Play animation 
        //anim.SetBool("smallEnding", true);
        yield return new WaitForSeconds(4);    
       // anim.SetBool("smallEnding", false);
        isSmall = false;
        rb.gravityScale = 0.6f;
        playerScript.moveSpeed = 3;
        player.transform.localScale = new Vector3(1,1,1);
        Destroy(gameObject);
    }
    
}
