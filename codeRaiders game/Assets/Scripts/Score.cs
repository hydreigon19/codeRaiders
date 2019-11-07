using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int kills;
    private Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        kills = GameObject.FindGameObjectWithTag("loader").GetComponent<Load>().kills;
    }
    void Update()
    {
        kills = GameObject.FindGameObjectWithTag("loader").GetComponent<Load>().kills;
        scoreText.text = "Kills: " + kills;
       
    }
    
}
