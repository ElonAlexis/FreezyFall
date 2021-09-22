using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float scrollSpeed;
    MeshRenderer meshRenderer;
    string textureName = "_MainTex";

    // Start is called before the first frame update
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
        ScrollFaster();
    }

    void Scroll()
    {
        Vector2 offset = meshRenderer.sharedMaterial.GetTextureOffset(textureName);
        offset.y += Time.deltaTime * scrollSpeed;

        meshRenderer.sharedMaterial.SetTextureOffset(textureName, offset);
    }


    void ScrollFaster()
    {
           if(GameManager.instance.score < 300)
        {            
            scrollSpeed = 0.07f;           
        }
        else if (GameManager.instance.score > 300 && GameManager.instance.score < 600)
        {       
            scrollSpeed = 0.15f;
        }
        else if (GameManager.instance.score > 600 && GameManager.instance.score < 900)
        {          
           scrollSpeed = 0.2f;
        }
        else if (GameManager.instance.score > 900 && GameManager.instance.score < 1200)
        {            
            scrollSpeed = 0.25f;
        }
        // else if(GameManager.instance.score > 1500)
        // {
         
        // }
    }
}
