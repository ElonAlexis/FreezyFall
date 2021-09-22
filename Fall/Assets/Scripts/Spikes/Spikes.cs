using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public PlayerScript playerScript; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //Destroy(other.gameObject.transform.parent.transform.parent);
            Destroy(other.gameObject.transform.parent.transform.parent.transform.parent);
            GameManager.instance.GameOver();
        }
    }
}
