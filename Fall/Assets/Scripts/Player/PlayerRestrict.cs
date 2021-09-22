using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRestrict : MonoBehaviour
{
    float minX = -2f, maxX = 2f, minY = -5f, maxY = 5.2f;

    // Update is called once per frame
    void Update()
    {
        Restrict();
    }

    void Restrict()
    {
        Vector2 position = transform.position;

        if (position.x > maxX)
        {
            position.x = maxX;
        }
        else if (position.x < minX)
        {
            position.x = minX;
        }

        transform.position = position; 

        if(position.y < minY)
        {
            Destroy(this.gameObject);            
            GameManager.instance.GameOver();
        }
        else if(position.y > maxY)
        {
            Destroy(this.gameObject);            
            GameManager.instance.GameOver();
        }

    }

}
