using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;
    public int damageAmount;
    private int secToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
        else
        {
            Destroy(this.gameObject, 2.0f);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<Health>().DealDamage(damageAmount);
            FindObjectOfType<AudioManager>().Play("Enemy Hurt");
            DestroyProjectile();
        }
        if(other.CompareTag("bullet"))
        {
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }
}