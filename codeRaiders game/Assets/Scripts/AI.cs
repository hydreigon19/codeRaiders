using System.Collections;
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

    public float startTime;
    public float TimeDelay;
    public bool CheckSpawn ;
    private Vector3 direction;
    public int itemSpawned = 0;

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
        if (speed > 0)
        {
            animator.SetFloat("AimingState", 1.0f);
        }
        
        else
        {
            animator.SetFloat("AimingState", 0.0f);
        
    }
        
        animator.SetFloat("Magnitude", direction.magnitude);
        
        //this was changed so the movement is correct
        if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
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
    }
    
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector3)transform.position + (this.direction * speed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Fire");  
        if (other.gameObject.CompareTag("Player"))
        {
           other.gameObject.GetComponent<Health>().DealDamage(6);
        }
        /*else{
            if (other.gameObject.CompareTag("bullet")){
                this.gameObject.GetComponent<AI>().takeDamage(1);
            }*/
        
    }
    public void Spawn()
    {
        Instantiate(healthitem, transform.position, Quaternion.identity);//spawns potion when enemy dies
       // itemSpawned++;


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
            if(CheckSpawn)
            {
                Spawn();
                itemSpawned++;
                Debug.Log("EnemyDeadSpawned !" + itemSpawned);
                gameObject.SetActive(false);
            }
            else
            {
                Instantiate(healthitem,transform.position, Quaternion.identity);//spawns potion when enemy dies
           
                Destroy(gameObject);

            }
        }
    }
}

