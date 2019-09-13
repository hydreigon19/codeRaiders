using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float rotationSpeed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public Animator animator;
    void Update()
    {
        
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal")*speed, Input.GetAxis("Vertical") * speed, 0.0f);
        rb.AddForce(movement * speed);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);
        transform.position = transform.position + movement * Time.deltaTime;
      
        // transform.position = transform.position + vertical * Time.deltaTime;
    }

    //rotate player
    void RotatePlayer()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x)* Mathf.Rad2Deg - 90;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }

    void FixedUpdate()//move our character
    {

    }
}
