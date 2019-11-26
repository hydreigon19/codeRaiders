using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerJT : MonoBehaviour
{


    public Animator animator;
    public float speed;
    public float runSpeed;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0.0f);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);
        while(Input.GetKeyDown(KeyCode.UpArrow))//NorthEast
        {
            if( Input.GetKeyDown(KeyCode.RightArrow))
            {
                animator.SetBool("North", true);
                animator.SetBool("East", true);
                animator.SetBool("South", false);
                animator.SetBool("West", false);
            }
        }
        while (Input.GetKeyDown(KeyCode.UpArrow)) //NorthWest
        {
            if( Input.GetKeyDown(KeyCode.LeftArrow))
            {
                animator.SetBool("North", true);
                animator.SetBool("East", false);
                animator.SetBool("South", false);
                animator.SetBool("West", true);
            }
            
        }
        while(Input.GetKeyDown(KeyCode.DownArrow)) //SouthEast
        {
            if( Input.GetKeyDown(KeyCode.RightArrow))
            {
                animator.SetBool("North", false);
                animator.SetBool("East", true);
                animator.SetBool("South", true);
                animator.SetBool("West", false);
            }
            
        }
        while (Input.GetKeyDown(KeyCode.DownArrow)) //SouthWest
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                animator.SetBool("North", false);
                animator.SetBool("East", false);
                animator.SetBool("South", true);
                animator.SetBool("West", true);
            }
           
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)) //North
        {
            animator.SetBool("North", true);
            animator.SetBool("East", false);
            animator.SetBool("South", false);
            animator.SetBool("West", false);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow)) //East
        {
            animator.SetBool("North", false);
            animator.SetBool("East", true);
            animator.SetBool("South", false);
            animator.SetBool("West", false);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))//South
        {
            animator.SetBool("North", false);
            animator.SetBool("East", false);
            animator.SetBool("South", true);
            animator.SetBool("West", false);
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))//west
        {
            animator.SetBool("North", false);
            animator.SetBool("East", false);
            animator.SetBool("South", false);
            animator.SetBool("West", true);
        }
        if(animator.GetBool("Run")==false)
        {
            transform.position = transform.position + movement * speed * Time.deltaTime;
        }
        else if(animator.GetBool("Run")==true)
        {
            transform.position = transform.position + movement * runSpeed * Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("Run", true);
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("Run", false);
        }
    }
    
}
