using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSpike : MonoBehaviour
{
    Animator anim;
    


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Shatter", true);
            Destroy(collision.gameObject.transform.parent.transform.parent.transform.parent);
            GameManager.instance.GameOver();
        }
       
    }

    void Destroy()
    {
        Destroy(gameObject);
    }


}
