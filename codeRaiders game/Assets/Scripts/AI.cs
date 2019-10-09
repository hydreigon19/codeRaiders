﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float stoppingDistance;
    private Transform target;
    public float health = 100;
    public GameObject healthitem;
    private Vector2 movement;
    private Vector3 direction;
    private Rigidbody2D rb;
    public Animator animator;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        rb.AddForce(direction * speed); //do we need this??

        //should be part of the animation but something is off
        direction = target.position - transform.position;
        if (direction != Vector3.zero)
        {
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);

        }
        animator.SetFloat("Magnitude", direction.magnitude);
        
        //this was changed so the movement is correct
        if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        
    }
    
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector3)transform.position + (this.direction * speed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Fire");  
        if (other.gameObject.CompareTag("Player"))
        {
           other.gameObject.GetComponent<Health>().DealDamage(6);
        }
        /*else{
            if (other.gameObject.CompareTag("bullet")){
                this.gameObject.GetComponent<AI>().takeDamage(1);
            }*/
        
    }

    public void takeDamage(float number)
    {
        if (health > 0)
        {
            Debug.Log("Ouch!");
            health = health - number;
        }
        else
        {
            Debug.Log("EnemyDead!");
            Instantiate(healthitem,transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}

