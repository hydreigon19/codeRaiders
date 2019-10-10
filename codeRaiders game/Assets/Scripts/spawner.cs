using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoint;
    

    private int rand;
    private int randPosition;


    public float startTimeBtwSpawns;
    public float timeBtwSpawns;
    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }
    private void Update()
    {
        if(timeBtwSpawns <=0)
        {
            randPosition = Random.Range(0, spawnPoint.Length);
            Instantiate(enemies[0], spawnPoint[randPosition].transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;

        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
