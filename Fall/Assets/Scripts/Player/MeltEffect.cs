using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltEffect : MonoBehaviour
{
    public GameObject iceCube;
    public GameObject player; 
    public GameObject topSpikes;
    float distance; 
    Animator anim; 
    bool active = true; 
    PlayerScript playerScript;

    void Start()
    {
         if(active)
        {
            iceCube.transform.localScale += new Vector3(.3f,.3f,.3f); 
        }
        playerScript = player.GetComponent<PlayerScript>();

        if(playerScript != null)
        {
            Debug.Log("Its here!"); 
        }
        else
        {
            Debug.Log("Its not here!"); 
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = iceCube.transform.position.y - topSpikes.transform.position.y;
        Debug.Log("This is the distance between player and spikes " + distance);
        anim = GetComponent<Animator>(); 
        Animations();

        
    }

   void Animations()
   {
       if(distance  > 3)
       {
           anim.SetBool("isMelt04", true); 
           anim.SetBool("isMelt03", false);
           anim.SetBool("isMelt02", false);
           anim.SetBool("isMelt01", false);
           anim.SetBool("isMelt00", false); 
       }
       else if(distance  > 2 && distance  < 3)
       {
           anim.SetBool("isMelt03", true);
           anim.SetBool("isMelt04", false); 
           anim.SetBool("isMelt02", false);
           anim.SetBool("isMelt01", false);
           anim.SetBool("isMelt00", false); 
       }
       else if(distance  > 1  && distance  < 2)
       {
           anim.SetBool("isMelt02", true);
           anim.SetBool("isMelt03", false);
           anim.SetBool("isMelt04", false);
           anim.SetBool("isMelt01", false);
           anim.SetBool("isMelt00", false); 
       }
       else if(distance  > 0   && distance  < 1)
       {
           anim.SetBool("isMelt01", true);
           anim.SetBool("isMelt03", false);
           anim.SetBool("isMelt02", false);
           anim.SetBool("isMelt04", false);
           anim.SetBool("isMelt00", false); 
       }
       if(distance  < 0)
       {
           anim.SetBool("isMelt00", true);
           anim.SetBool("isMelt03", false);
           anim.SetBool("isMelt02", false);
           anim.SetBool("isMelt01", false);
           anim.SetBool("isMelt04", false);  
       }

//        if(distance  >= 3)
//        {
//            if(playerScript.isGrounded)
//            {
//                 anim.SetBool("isMelt04", true); 
//                 anim.SetBool("isMelt03", false);
//                 anim.SetBool("isMelt02", false);
//                 anim.SetBool("isMelt01", false);
//                 anim.SetBool("isMelt00", false); 
//                 anim.SetBool("isFalling04", false);
//                 anim.SetBool("isFalling03", false);
//                 anim.SetBool("isFalling02", false);
//                 anim.SetBool("isFalling01", false);
//                 anim.SetBool("isFalling00", false);
//            }
//            else if(!playerScript.isGrounded)
//            {
//                 anim.SetBool("isFalling04", true);
//                 anim.SetBool("isMelt04", false); 
//                 anim.SetBool("isMelt03", false);
//                 anim.SetBool("isMelt02", false);
//                 anim.SetBool("isMelt01", false);
//                 anim.SetBool("isMelt00", false); 
//                 anim.SetBool("isFalling03", false);
//                 anim.SetBool("isFalling02", false);
//                 anim.SetBool("isFalling01", false);
//                 anim.SetBool("isFalling00", false); 
//            }
//        }
//        else if(distance  >= 2 && distance  < 3)
//        {
//            if(playerScript.isGrounded)
//            {                
//                 anim.SetBool("isMelt03", true);
//                 anim.SetBool("isMelt04", false);
//                 anim.SetBool("isMelt02", false);
//                 anim.SetBool("isMelt01", false);
//                 anim.SetBool("isMelt00", false); 
//                 anim.SetBool("isFalling04", false);
//                 anim.SetBool("isFalling03", false);
//                 anim.SetBool("isFalling02", false);
//                 anim.SetBool("isFalling01", false);
//                 anim.SetBool("isFalling00", false);
//            }
//            else if(!playerScript.isGrounded)
//            {
//                 anim.SetBool("isFalling03", true);
//                 anim.SetBool("isMelt04", false); 
//                 anim.SetBool("isMelt03", false);
//                 anim.SetBool("isMelt02", false);
//                 anim.SetBool("isMelt01", false);
//                 anim.SetBool("isMelt00", false); 
//                 anim.SetBool("isFalling04", false);
//                 anim.SetBool("isFalling02", false);
//                 anim.SetBool("isFalling01", false);
//                 anim.SetBool("isFalling00", false); 
//            }
//        }
//        else if(distance  >= 1  && distance  < 2)
//        {
//            if(playerScript.isGrounded)
//            {                
//                 anim.SetBool("isMelt02", true);
//                 anim.SetBool("isMelt04", false);
//                 anim.SetBool("isMelt03", false);
//                 anim.SetBool("isMelt01", false);
//                 anim.SetBool("isMelt00", false); 
//                  anim.SetBool("isFalling04", false);
//                 anim.SetBool("isFalling03", false);
//                 anim.SetBool("isFalling02", false);
//                 anim.SetBool("isFalling01", false);
//                 anim.SetBool("isFalling00", false);
//            }
//            else if(!playerScript.isGrounded)
//            {
//                 anim.SetBool("isFalling02", true);
//                 anim.SetBool("isMelt02", false); 
//                 anim.SetBool("isMelt03", false);
//                 anim.SetBool("isMelt04", false);
//                 anim.SetBool("isMelt01", false);
//                 anim.SetBool("isMelt00", false); 
//                  anim.SetBool("isFalling04", false);
//                 anim.SetBool("isFalling03", false);
//                 anim.SetBool("isFalling01", false);
//                 anim.SetBool("isFalling00", false); 
//            }
//        }
//        else if(distance  >= 0   && distance  < 1)
//        {
//             if(playerScript.isGrounded)
//            {                
//                 anim.SetBool("isMelt01", true);
//                 anim.SetBool("isMelt04", false);
//                 anim.SetBool("isMelt03", false);
//                 anim.SetBool("isMelt02", false);
//                 anim.SetBool("isMelt00", false); 
//                 anim.SetBool("isFalling04", false);
//                 anim.SetBool("isFalling03", false);
//                 anim.SetBool("isFalling02", false);
//                 anim.SetBool("isFalling01", false);
//                 anim.SetBool("isFalling00", false);
//            }
//            else if(!playerScript.isGrounded)
//            {
//                 anim.SetBool("isFalling01", true);
//                 anim.SetBool("isMelt01", false); 
//                 anim.SetBool("isMelt03", false);
//                 anim.SetBool("isMelt04", false);
//                 anim.SetBool("isMelt02", false);
//                 anim.SetBool("isMelt00", false); 
//                  anim.SetBool("isFalling04", false);
//                 anim.SetBool("isFalling03", false);
//                 anim.SetBool("isFalling02", false);
//                 anim.SetBool("isFalling00", false);
//            }
//        }
//        else if(distance < 0)
//        {
//             if(playerScript.isGrounded)
//            {                
//                 anim.SetBool("isMelt00", true);
//                 anim.SetBool("isMelt04", false);
//                 anim.SetBool("isMelt03", false);
//                 anim.SetBool("isMelt02", false);
//                 anim.SetBool("isMelt01", false); 
//                  anim.SetBool("isFalling04", false);
//                 anim.SetBool("isFalling03", false);
//                 anim.SetBool("isFalling02", false);
//                 anim.SetBool("isFalling01", false);
//                 anim.SetBool("isFalling00", false);
//            }
//            else if(!playerScript.isGrounded)
//            {
//                 anim.SetBool("isFalling00", true);
//                 anim.SetBool("isMelt00", false); 
//                 anim.SetBool("isMelt03", false);
//                 anim.SetBool("isMelt04", false);
//                 anim.SetBool("isMelt02", false);
//                 anim.SetBool("isMelt01", false); 
//                  anim.SetBool("isFalling04", false);
//                 anim.SetBool("isFalling03", false);
//                 anim.SetBool("isFalling02", false);
//                 anim.SetBool("isFalling01", false);
//            }
//        }
    }


}
