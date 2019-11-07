using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPress");
        SceneManager.LoadScene("NeverUnload");
    }
    public void QuitGame()
    {
        //Dubug.Log("QUIT");
        FindObjectOfType<AudioManager>().Play("ButtonPress");
        Application.Quit();
    }
    public void click()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
