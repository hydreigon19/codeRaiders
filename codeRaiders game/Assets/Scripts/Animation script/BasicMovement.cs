using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public GameObject crosshair;
    public GameObject bulletPrefab;
    public bool endOfAiming;

    public float Crosshair_Distance = 1.0f;
    public float BULLET_BASE_SPEED = 1.0f;

    public Rigidbody2D rb;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    
    void Update()
    {

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0.0f);
        

        rb.AddForce(movement * speed);

        MoveCrossHair();
        Shoot();

        if (movement != Vector3.zero)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);

        }
        animator.SetFloat("Magnitude", movement.magnitude);
        transform.position = transform.position + movement * Time.deltaTime;

        endOfAiming = Input.GetButtonUp("Fire1");

        // transform.position = transform.position + vertical * Time.deltaTime;
    }
    void FixedUpdate()//move our character
    {

    }

    void MoveCrossHair(){
        Vector2 aim = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if(aim != Vector2.zero){
            if(aim.magnitude > 0.0f){
                aim.Normalize();
                crosshair.transform.localPosition = aim * Crosshair_Distance;

            }
            //crosshair.transform.localPosition = aim * Crosshair_Distance;
        }
    }
    
    void Shoot(){
        Vector2 shootingDirection = crosshair.transform.localPosition;
        shootingDirection.Normalize();

        if(endOfAiming){
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = shootingDirection * BULLET_BASE_SPEED;
            bullet.transform.Rotate(0,0, Mathf.Atan2(shootingDirection.y, shootingDirection.x)* Mathf.Rad2Deg);
            Destroy(bullet, 2.0f);
        }

    }
    
}
