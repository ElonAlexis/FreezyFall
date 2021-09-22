using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaySmall : MonoBehaviour
{
    PlayerScript playerScript; 
    Rigidbody2D rb;
    GameObject player;
    GameObject skin;

    bool isSmall = false; 

    void Start()
    {
        player = GameObject.Find("Player");
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
            isSmall = true;
            if(isSmall)
            {
                other.gameObject.transform.localScale = new Vector3 (0.3f,0.3f,0.3f);
            }           
            rb = other.gameObject.GetComponent<Rigidbody2D>();
            rb.gravityScale = 2f;
            playerScript  = other.gameObject.GetComponent<PlayerScript>();
            playerScript.moveSpeed += 1;
            gameObject.transform.position = new Vector3(5,5,5);

            
        }
    }

    IEnumerator Timer()
    {
        Debug.Log("Started");
        yield return new WaitForSeconds(7);    
        Debug.Log("Reached");
        isSmall = false;
        rb.gravityScale = 0.6f;
        playerScript.moveSpeed = 3;
        player.transform.localScale = new Vector3(1,1,1);
        Destroy(gameObject);
    }
    
}
