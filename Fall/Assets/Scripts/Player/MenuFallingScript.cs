using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFallingScript : MonoBehaviour
{
    float minY = -15f, maxY = 6f;
    float movesSpeed =5f;
    float minX = -2f, maxX = 2f;

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
