using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    // Start is called before the first frame update
    //Input Settings
    public int playerid;
    public bool useController;
    Input player;
    //---------------//
    //Character Attributes
    public float MOVEMENT_BASE_SPEED = 1.0f;
    public float CROSSHAIR_DISTANCE = 1.0f;
    public float BULLET_BASE_SPEED = 1.0f;
    public float AIMING_BASE_PENALTY = 1.0f;
    public float SHOOTING_RECOIL_TIME = 1.0f;
    //-----------------------------------//
    //----Character stats--------------//
    public Vector2 movementDirection;
    public Vector2 mouseMovement;
    public float movementSpeed;
    public bool endOfAiming;
    public bool IsAiming;
    //public bool lockPosition;
    public float shootingRecoil = 0;

    //-----------------------------//

    //---------Reference--------------//
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject crosshair;
    public GameObject bulletPrefab;
    public Camera cam;
    public Vector2 mousePos;
    Vector3 target;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        ProcessInputs();
        Move();
        Animate();
        Aim();

       
        Shoot();
        
        



    }
    void ProcessInputs()
    {


        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
        

        //INTITIAL SHOOT
        
        endOfAiming = Input.GetKeyDown("space");
        IsAiming = Input.GetKeyDown("space");
        //lockPosition = Input.GetButton("LockPosition");
      
        if(endOfAiming)
        {
            shootingRecoil = SHOOTING_RECOIL_TIME;
        }
        if(shootingRecoil>0.0f)
        {
            shootingRecoil -= Time.deltaTime;
        }
        


    }
    void Move()
    {


       rb.velocity = movementDirection * movementSpeed * MOVEMENT_BASE_SPEED;
       //rb.AddForce(movementDirection * movementSpeed);


    }
    void Animate()
    {
        if (movementDirection != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);

        }
       
         if (shootingRecoil > 0.0f)
        {
            animator.SetFloat("AimingState", 1.0f);
        }
         else if(shootingRecoil>0.0f && movementSpeed == 0)
        {
            animator.SetFloat("AimingState",2.0f);
        }
        else if(movementSpeed > 0)
        {
            animator.SetFloat("AimingState",.5f);
            
        }
        else
        {
            animator.SetFloat("AimingState", 0.0f);
        }
        animator.SetFloat("Magnitude", movementDirection.magnitude);
        animator.SetFloat("Speed", movementSpeed);
      //  transform.position = transform.position + movementDirection * Time.deltaTime;

    }
    void Aim()
    {
        Vector2 aim = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (aim != Vector2.zero)
        {
            if (aim.magnitude > 0.0f)
            {
                aim.Normalize();
                crosshair.transform.localPosition = aim * CROSSHAIR_DISTANCE;
            }
        }
    }

    void Shoot()
    {
        
        //INITIAL SHOOT
        
        Vector2 shootingDirection = crosshair.transform.localPosition;
        shootingDirection.Normalize();

        if (endOfAiming)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = shootingDirection * BULLET_BASE_SPEED;
            bullet.transform.Rotate(0, 0, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
            Destroy(bullet, 2.0f);
        }
    
    }

}

