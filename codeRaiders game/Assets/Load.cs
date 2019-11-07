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
    void Start()
    {
        kills = 0;
    }
    void Update()
    {
        if(kills>=killAmount)
        {
            if(!loaded)
            {
                
                SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
                kills = 0;
                loaded = true;
            }
        }
    }

}
