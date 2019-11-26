using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstRoom : MonoBehaviour
{
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i] != null)
                {
                    enemies[i].gameObject.GetComponent<AIFirstLevel>().SetFollow();
                }
            }
        }
    }
}
