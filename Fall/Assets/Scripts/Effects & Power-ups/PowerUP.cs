using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : MonoBehaviour
{
    GameObject player;
    Rigidbody rb; 


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
        rb = player.GetComponent<Rigidbody>(); 
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // Implement power-up ability here 
            
            // Destroy Gameobject and powerup 
            Destroy(this.gameObject);
            Destroy(collision.gameObject); 

        }

    }
}
