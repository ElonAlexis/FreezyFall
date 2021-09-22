using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlurbyAnimations : MonoBehaviour
{

    SpriteRenderer spr;
    [SerializeField] SpriteRenderer fallImage;


    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        TouchMove();
    }

    void TouchMove()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousepos.x > 0)
            {
                spr.flipX = false;
                fallImage.flipX = false;

            }
            else if (mousepos.x < 0)
            {
                spr.flipX = true;
                fallImage.flipX = true;

            }
        }
    }
    void Move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            spr.flipX = false;
            fallImage.flipX = false;

        }
        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            spr.flipX = true;
            fallImage.flipX = true;

        }

    }
}
