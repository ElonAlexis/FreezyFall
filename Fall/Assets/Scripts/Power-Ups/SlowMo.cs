using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMo : MonoBehaviour
{
    public TimeManager timeManager; 
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            timeManager.SlowMotion();         
            Destroy(gameObject);
        }
    }
}
