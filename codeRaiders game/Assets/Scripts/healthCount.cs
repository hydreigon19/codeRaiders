using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthCount : MonoBehaviour
{
    public int[] healthCnt;
    public GameObject player;
    private Text countText;
    // Start is called before the first frame update
    void Start()
    {
        countText = GetComponent<Text>();
        player = GameObject.FindWithTag("Player");
        healthCnt = player.GetComponent<Inventory>().itemCount;
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(healthCnt[0]);
        countText.text = "X: "+healthCnt[0];
    }
}
