using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyManager : MonoBehaviour
{
    public static AnyManager anyManager;
    bool gameStart;
    public GameObject levelText;
    
    void Awake()
    {
        if(!gameStart)
        {
            levelText = GameObject.FindGameObjectWithTag("levelDisplay");

            anyManager = this;
            SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
            StartCoroutine(myMethod());
            gameStart = true;
        }
       
    }
    public void UnloadScene(int scene)
    {
        StartCoroutine(Unload(scene));
    }
    IEnumerator Unload(int scene)
    {
        yield return null;
        SceneManager.UnloadSceneAsync(scene);
        levelText.GetComponent<LevelScript>().level += 1;
        SceneManager.LoadSceneAsync(scene + 1, LoadSceneMode.Additive);
        levelText.SetActive(true);
        yield return new WaitForSeconds(2);
        levelText.SetActive(false);

    }
    IEnumerator myMethod()
    {

        levelText.SetActive(true);
        yield return new WaitForSeconds(2);
        levelText.SetActive(false);
    }


}
