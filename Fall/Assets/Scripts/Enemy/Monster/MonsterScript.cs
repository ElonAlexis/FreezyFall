using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    Animator anim;
    public GameObject eatPoint;
    public GameObject Player;
    Rigidbody2D playerRB;
   


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
        playerRB = Player.GetComponent<Rigidbody2D>();
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
             anim.SetBool("isBiting", true);
             playerRB.isKinematic = true;
             other.gameObject.transform.position = new Vector3(eatPoint.transform.position.x, eatPoint.transform.position.y , eatPoint.transform.position.z -2) ;
             other.gameObject.transform.SetParent(eatPoint.transform);
        }
    }

    void Destroy()
    {
        Destroy(this.gameObject);
        GameManager.instance.GameOver();
        
    }
}
