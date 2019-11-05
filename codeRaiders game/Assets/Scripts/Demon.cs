using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public Transform player;
    public int MaxHealth;
    public int damage;
    public float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,player.position) >=stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position,player.position)<stoppingDistance && Vector2.Distance(transform.position,player.position)>retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position,player.position)<retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if(timeBtwShots<=0)
        {
            Instantiate(projectile,transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -=Time.deltaTime;
        }
        
        death();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Fire");  
        if (other.gameObject.CompareTag("bullet"))
        {
            
           MaxHealth = MaxHealth-damage;
        }
        
        /*else{
            if (other.gameObject.CompareTag("bullet")){
                this.gameObject.GetComponent<AI>().takeDamage(1);
        }*/
    }
    void death()
    {
        if(MaxHealth<=0)
        {
            Destroy(this.gameObject);
        }
    }
}
 