using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float stoppingDistance;
    private Transform target;
    public float health = 100;
    public GameObject healthitem;
    private Vector2 movement;
    public float retreatDistance;
    public float startTime;
    public float TimeDelay;
    public bool CheckSpawn ;
    private Vector3 direction;
    public int itemSpawned = 0;
    public bool found;
    public float timeBtwShots;
    public float startTimeBtwShots;
    private Rigidbody2D rb;
    public Animator animator;
    public GameObject player;
    public GameObject projectile;
    public GameObject effect;

    //public CameraShake cameraShake;

    float curTime = 0;
    float nextDamage = 1;
    float curTimeDrop = 0;
    float nextTime = 15;

    public Load load1;
    void Start()
    {
        load1 = GameObject.FindGameObjectWithTag("loader").GetComponent<Load>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody2D>();
       // player = GameObject.FindGameObjectWithTag("Player");
        CheckSpawn = false;
        timeBtwShots = startTimeBtwShots;
        found = false;
        


        
    }

    // Update is called once per frame
    void Update()
    {

        //rb.AddForce(direction * speed); //do we need this??

        //should be part of the animation but something is off
        direction = target.position - transform.position;

        if (direction != Vector3.zero)
        {
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);

        }
        if (speed > 0)
        {
            animator.SetFloat("AimingState", 1.0f);
          //  Instantiate(projectile, direction, Quaternion.identity);
        }
        
        else
        {
            animator.SetFloat("AimingState", 0.0f);
        
    }
        
        animator.SetFloat("Magnitude", direction.magnitude);

        if (Vector2.Distance(transform.position, target.position) >= stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
        if (found == true)//Credits to JT..I used the same exact structure as his code from the lava_damage script// this is a timer for when the enemy is touching player the health goes down
        {
            if (curTime <= 0)
            {
                target.GetComponent<Health>().DealDamage(6);
                curTime = nextDamage;
            }
            else
            {

                curTime -= Time.deltaTime;
            }


        }
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
      
    
      
  
        if (TimeDelay <= 0)
        {
           
            CheckSpawn = true;
            TimeDelay = startTime;
          //  Debug.Log("Start Time : "+startTime+" Time Delay Update: " + TimeDelay);
            
        }
        else
        {
            TimeDelay -= Time.time;
           // Debug.Log("StartTime "+startTime+" Time Delay Update when time is not 0: " + TimeDelay);
            CheckSpawn = false;
        }
        /*if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }*/
        
    
}


    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Fire");  
        if (other.gameObject.CompareTag("Player"))
        {
            found = true;//bool to see if enemy is touching player
      
        }
        
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            found = false;
        }
    }


//spawn function
public void Spawn()
    {
        //spawns potion when enemy dies
        Instantiate(healthitem, transform.position, Quaternion.identity);
        //spawns potion when enemy dies
        


    }

    public void takeDamage(float number)
    {
        if (health > 0)
        {
            //Debug.Log("Ouch!");
            health = health - number;
        }
        else
        {
            load1.kills += 1;
            load1.bossKills += 1;
            //when enemy has 0 health
            //triggers particle effects
           /* Instantiate(effect, transform.position, Quaternion.identity);
           
            //deletes enemy object
            Destroy(gameObject);*/

            //item spawn; probably need to implement differently
            
            if(CheckSpawn)//needs to be fixed
            {
                Spawn();
                Instantiate(effect, transform.position, Quaternion.identity);
                itemSpawned++;
                Debug.Log("EnemyDeadSpawned !" + itemSpawned);
                Destroy(gameObject);
            }
            else
            {
             
                   
                Destroy(gameObject);

            }
            
        }
    }
}

