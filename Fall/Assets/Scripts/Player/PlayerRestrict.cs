using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRestrict : MonoBehaviour
{
    float screenEdgeOffset = 0.3f;

    // Update is called once per frame
    void Update()
    {
        Restrict();
    }

    void Restrict()
    {
        Vector2 position = transform.position;

        // Get the screen boundaries
        float screenWidth = Screen.width;
        float leftBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        float rightBoundary = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, 0, 0)).x;

        float screenHeight = Screen.height;
        float bottomBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        float topBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0, screenHeight, 0)).y;


        // Clamp the player's _position within the screen boundaries
        position.x = Mathf.Clamp(position.x, leftBoundary + screenEdgeOffset, rightBoundary - screenEdgeOffset);

        transform.position = position;

        if (position.y < bottomBoundary || position.y > topBoundary)
        {
            Destroy(this.gameObject);
            GameManager.instance.GameOver();
        }
    }


}
