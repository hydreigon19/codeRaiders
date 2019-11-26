using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRoomBoss : MonoBehaviour
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
                enemies[i].gameObject.GetComponent<BossFirstLevel>().SetFollow();
            }
        }
    }
}
