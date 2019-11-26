using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poisonScript : MonoBehaviour
{
    public bool in_poison;
    public bool doDamage;
    public GameObject player;
    public int damage_amount;
    float curTime = 0;
    float nextDamage = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        in_poison=false;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Fire");  
        if (other.gameObject.CompareTag("Player"))
        {
            
            in_poison=true;
            StartCoroutine(enterPoison());
           
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
            in_poison=false;
            StartCoroutine(myMethod());
            
        }
    } 
    
    IEnumerator myMethod()
    {
 
        player.GetComponent<Health>().DealDamage(damage_amount);
        yield return new WaitForSeconds(.5f);
        player.GetComponent<Health>().DealDamage(damage_amount);
        yield return new WaitForSeconds(.5f);
        player.GetComponent<Health>().DealDamage(damage_amount);
        yield return new WaitForSeconds(.5f);
        player.GetComponent<Health>().DealDamage(damage_amount);
  
    }
    IEnumerator enterPoison()
    {
        while(in_poison==true)
        {
        player.GetComponent<Health>().DealDamage(damage_amount);
        yield return new WaitForSeconds(.5f);
        }
  
    }
}
