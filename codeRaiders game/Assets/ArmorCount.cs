using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorCount : MonoBehaviour
{
    public int[] armorCnt;
    public GameObject player;
    private Text countText;
    // Start is called before the first frame update
    void Start()
    {
        countText = GetComponent<Text>();
        player = GameObject.FindWithTag("Player");
        armorCnt = player.GetComponent<Inventory>().itemCount;
    }

    // Update is called once per frame
    void Update()
    {

        
        countText.text = "X: " + armorCnt[1];
    }
}
