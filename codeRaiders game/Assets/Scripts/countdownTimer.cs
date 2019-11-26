using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class countdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    public float startingTime = 180f;

    [SerializeField] Text countdownText;
    public GameObject menuContainer;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if(currentTime <= 0 ){
            currentTime = 0;
        }
        if(currentTime==0)
        {
            player.SetActive(false);
            menuContainer.SetActive(true);
        }
    }
    public void setTime(float time)
    {
        startingTime = time;
        currentTime = startingTime;
    }
}
