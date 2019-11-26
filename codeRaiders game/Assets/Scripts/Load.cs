using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    public int scene;
    public bool loaded;
    public int kills;
    public int killAmount;
    public int bossNum;
    public int bossKills;
    public GameObject player;
    void Start()
    {
        kills = 0;
        loaded=false;
        bossKills=0;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if(!loaded)
        {
        if(kills>=killAmount)
        {
                player.transform.position = new Vector2(0, 0);
                AnyManager.anyManager.UnloadScene(scene);
                SceneManager.LoadSceneAsync(scene + 1, LoadSceneMode.Additive);
                
                loaded = true;
            
        }
        }
    }

}
