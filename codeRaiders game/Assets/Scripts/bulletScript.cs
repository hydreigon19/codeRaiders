using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float amount_damage = 0.5f;

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");
        if (other.gameObject.CompareTag("enemy"))
        {
          other.gameObject.GetComponent<AI>().takeDamage(amount_damage);
          DestroyProjectile();
        }
        if( other.gameObject.CompareTag("wall"))
        {
          DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }
}
