﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincible : MonoBehaviour
{   
    Collider2D col;
    public GameObject iShield; 
    GameObject shield;
    Animator anim; 

    void Start()
    {
        anim = iShield.GetComponent<Animator>();
    }

    void Update()
    {
        StartCoroutine(Timer());
    }
    void OnCollisionEnter2D(Collision2D other)
    {
         if(other.gameObject.tag == "Player")
        {
           gameObject.transform.parent = null;
           shield = Instantiate(iShield, new Vector3(other.gameObject.transform.position.x,other.gameObject.transform.position.y,other.gameObject.transform.position.z +0.03f), Quaternion.identity);
           shield.transform.SetParent(other.gameObject.transform);
           //shield.transform._position = new Vector3(other.gameObject.transform._position.x,other.gameObject.transform._position.y,other.gameObject.transform._position.z +0.03f);
           col = other.gameObject.transform.GetChild(0).transform.GetComponentInChildren<Collider2D>();
           col.enabled = false;
           gameObject.transform.position = new Vector3 (5,5,5);
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(10);
        // Play Timeout Animation here
        ShieldAnimation.anim.SetBool("isFading", true);
        yield return new WaitForSeconds(5);
        if(col.enabled == false )
        {
            col.enabled = true;
        }
        Destroy(shield);
        Destroy(gameObject);

    }


}
