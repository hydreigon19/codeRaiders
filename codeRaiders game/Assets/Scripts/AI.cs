using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Transform player;
    private Vector2 movement;
    private Vector3 direction;
    private Rigidbody2D rb;
   
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
    public Animator animator;
    void Update()
    {

        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0.0f);
        direction = player.position - transform.position;
    
        rb.AddForce(direction * speed);
        if (direction != Vector3.zero)
        {
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);

        }

        animator.SetFloat("Magnitude", direction.magnitude);
        transform.position = transform.position + direction * Time.deltaTime;
     
        /* Vector3 direction = player.position - transform.position;
         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
         rb.rotation = angle;
         direction.Normalize();
         movement = direction;*/

       

    }
    void FixedUpdate()//move our character
    {
        moveCharacter(direction);
    }
    void moveCharacter(Vector3 direction)
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
    }
    void OnTriggerExit2D(Collider2D collider)
    {
      
    }

}