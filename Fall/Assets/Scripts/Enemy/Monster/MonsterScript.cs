using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    Animator anim;
    public GameObject Player;
    Rigidbody2D playerRB;
    [SerializeField] float pushForce;
   


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
        playerRB = Player.GetComponent<Rigidbody2D>();
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
         if (other.gameObject.tag == "Player")
    {
        Debug.Log("Collided with monster");
        
        // Calculate the direction from the monster to the player
        Vector2 direction = other.transform.position - transform.position;

        // Normalize the direction and multiply it by a push force
        direction = direction.normalized;
        Vector2 pushVector = direction * pushForce;

        // Apply the push force to the player's rigidbody
        playerRB.AddForce(pushVector, ForceMode2D.Impulse);
    }
    }
}
