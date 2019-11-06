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
        if(scoreAmount == 12){
            Switch();
        }
        else if(scoreAmount >= 6)
        {
            if(Input.GetKeyDown(KeyCode.E)){
                Switch2();
            }
        }
    }
    public void Switch()
    {
        SceneManager.LoadScene("level2");
    }
    public void Switch2()
    {
        SceneManager.LoadScene("level3");
    }
}
