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
    //-----------------------------------//
    //----Character stats--------------//
    public Vector3 movementDirection;
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


        movementDirection = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, Input.GetAxis("Vertical") * movementSpeed, 0.0f);
        // rb.AddForce(movementDirection * movementSpeed);
        //   movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        //  movementDirection.Normalize();
        endOfAiming = Input.GetButton("Fire1");
        IsAiming = Input.GetButton("Fire1");
        // lockPosition = Input.GetButton("LockPosition");



    }
    void Move()
    {


        //  rb.velocity = movementDirection * movementSpeed * MOVEMENT_BASE_SPEED;
        rb.AddForce(movementDirection * movementSpeed);


    }
    void Animate()
    {
        if (movementDirection != Vector3.zero)
        {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);

        }

        animator.SetFloat("Magnitude", movementDirection.magnitude);
        transform.position = transform.position + movementDirection * Time.deltaTime;

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
            //crosshair.transform.localPosition = aim * Crosshair_Distance;
        }
    }

    void FixedUpdate()
    {

    }
    void Shoot()
    {
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



/*void Start()
{
    rb = GetComponent<Rigidbody2D>();
}

// Update is called once per frame

void Update()
{

    Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, Input.GetAxis("Vertical") * movementSpeed, 0.0f);


    rb.AddForce(movement * movementSpeed);

    MoveCrossHair();


    if (movement != Vector3.zero)
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

    }
    animator.SetFloat("Magnitude", movement.magnitude);
    transform.position = transform.position + movement * Time.deltaTime;

       endOfAiming = Input.GetButtonUp("Fire1");
       Shoot();

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
            crosshair.transform.localPosition = aim * CROSSHAIR_DISTANCE;

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
*/
