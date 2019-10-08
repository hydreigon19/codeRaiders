﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float amount_damage = 2;

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");  
        if (other.gameObject.CompareTag("enemy"))
        {
            other.gameObject.GetComponent<AI>().takeDamage(amount_damage);
        }
    }
}
