using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFallingScript : MonoBehaviour
{
    [SerializeField] float minY = -0.541f, maxY = 3f;
    [SerializeField] float movesSpeed =0.5f;
    [SerializeField] float minX = -0.241f, maxX = 0.247f;

    Vector2 position;
    
    private void Start()
    {
        position = transform.position;
        position.x = Random.Range(minX, maxX);
    }

    // Update is called once per frame
    void Update()
    {
        position.y -= movesSpeed * Time.deltaTime;
        
        if (position.y < minY)
        {
            position.y = maxY;
            position.x = Random.Range(minX, maxX);
        }

        transform.position = position;
    }
}
