using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    public int scene;
    public bool loaded;
    public int kills;
    public int killAmount;
    public int bossNum;
    public int bossKills;
    public GameObject player;
    public GameObject Timer;
    public float time;
    public GameObject levelText;
    
    void Start()
    {
        kills = 0;
        loaded=false;
        bossKills=0;
        player = GameObject.FindGameObjectWithTag("Player");
        Timer = GameObject.FindGameObjectWithTag("timer");
        Timer.GetComponent<countdownTimer>().setTime(time);
        
        
        
    }
    void Update()
    {
        if(!loaded)
        {
            if(kills>=killAmount)
            {
                player.transform.position = new Vector2(0, 0);
                AnyManager.anyManager.UnloadScene(scene);
                
                
                loaded = true;
            
            }
        }
        
    }
    

}
