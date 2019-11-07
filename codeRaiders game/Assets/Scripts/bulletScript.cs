﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float amount_damage = 0.5f;
   

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");
        if (other.gameObject.CompareTag("enemy"))
        {
            FindObjectOfType<AudioManager>().Play("EnemyHit");
            other.gameObject.GetComponent<AI>().takeDamage(amount_damage);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Boss"))
        {
            other.gameObject.GetComponent<Boss>().takeDamage(amount_damage);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("pitchfork"))
        {
            Destroy(this.gameObject);
        }
    }
    }
