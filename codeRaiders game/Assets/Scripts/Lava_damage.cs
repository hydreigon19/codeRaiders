using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava_damage : MonoBehaviour
{
    public bool in_lava;
    public GameObject player;
    public int damage_amount;
    float curTime = 0;
    float nextDamage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindWithTag("Player");
        in_lava=false;
    }

    
    // Update is called once per frame
    void Update()
    {
        if(in_lava==true)
        {
            if (curTime <= 0) {
                player.GetComponent<Health>().DealDamage(damage_amount);
 
                curTime = nextDamage;
            }  
            else {
     
                curTime -= Time.deltaTime;
            }
            
            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Fire");  
        if (other.gameObject.CompareTag("Player"))
        {
            in_lava=true; 
           
        }
        
        /*else{
            if (other.gameObject.CompareTag("bullet")){
                this.gameObject.GetComponent<AI>().takeDamage(1);
        }*/
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            in_lava=false;
        }
    } 
}
