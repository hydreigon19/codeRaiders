using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoint;
    private int NumEnemies;
    private int NumSpawned;

    private int rand;
    private int randPosition;

    private int numBoss;
    public float startTimeBtwSpawns;
    public float timeBtwSpawns;
    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
        NumSpawned = 0;
        NumEnemies = GameObject.FindGameObjectWithTag("loader").GetComponent<Load>().numSpawn;
        numBoss = GameObject.FindGameObjectWithTag("loader").GetComponent<Load>().bossNum;
    }
    private void Update()
    {
        if(timeBtwSpawns <=0 && NumSpawned<NumEnemies)
        {
            randPosition = Random.Range(0, spawnPoint.Length);
            Instantiate(enemies[0], spawnPoint[randPosition].transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
            NumSpawned += 1;

        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
