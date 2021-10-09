using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFallingScript : MonoBehaviour
{
    float minY = -0.541f, maxY = 3f;
    float movesSpeed =0.5f;
    float minX = -0.241f, maxX = 0.247f;

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.y -= movesSpeed * Time.deltaTime;
        
        if (position.y < minY)
        {
            position.y = maxY;
            position.x = Random.Range(minX, maxX);
        }

        transform.position = position;
    }
}
