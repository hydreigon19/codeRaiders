using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int scoreAmount;
    private Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreAmount = 0;
    }
    void Update()
    {
        scoreText.text = "Score: " + scoreAmount;
        if(scoreAmount == 10){
            Switch();
        }
    }
    public void Switch()
    {
        SceneManager.LoadScene("level2");
    }
}
