using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] GameObject[] skins; 
    Rigidbody2D rb;
    public float moveSpeed = 2f;    
    GameObject fallingFace;
    public bool isGrounded;
    GameObject currentSkinFallface;
   

    // Start is called before the first frame update
    void Start()
    {       
        rb = GetComponent<Rigidbody2D>();
        ChangePlayerSkin();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        TouchMove();         
    }

    void Update()
    {
        FallFace();      
    }
    private void Move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
    }

    void TouchMove()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousepos.x > 1)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
            else if (mousepos.x < -1)
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            }
        }
    }

    void ChangePlayerSkin () 
    {
        Character character = GameDataManager.GetSelectedCharacter () ;
      if (character.image != null) 
      {
         // Get selected character's index:
         int selectedSkin = GameDataManager.GetSelectedCharacterIndex () ;

         // show selected skin's gameobject:
         skins [ selectedSkin ].SetActive (true) ;

         // hide other skins (except selectedSkin) :
         for (int i = 0; i < skins.Length; i++)
            if (i != selectedSkin)
               skins [ i ].SetActive (false) ;

      }

    }

    void FallFace()
    {
        int skinSelected = GameDataManager.GetSelectedCharacterIndex () ;

        currentSkinFallface = skins [skinSelected].transform.GetChild(0).gameObject;

        if(isGrounded)
        {
           currentSkinFallface.SetActive(false);         
        }
        else if(!isGrounded)
        {
            currentSkinFallface.SetActive(true); 
        }
        else if(currentSkinFallface == null)
        {
            return;
        }
     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform" )
        {
            isGrounded = true;
            SoundManager.instance.StopClip();
            SoundManager.instance.LandClip();
        }

        if(collision.gameObject.tag == "Coins")
        {
            GameDataManager.AddCoins(25);
            GameSharedUI.instance.UpdateCoinsUIText();
            Destroy(collision.gameObject);
            SoundManager.instance.CoinClip();

        }
        if(collision.gameObject.tag == "Power-Up")
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = false;
            SoundManager.instance.FallClip();
        }
    }

    

}


