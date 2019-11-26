using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOne : MonoBehaviour
{
    public int kills;
    public int numToKill;
    // Start is called before the first frame update
    void Start()
    {
        kills = GameObject.FindGameObjectWithTag("loader").GetComponent<Load>().kills;
    }

    // Update is called once per frame
    void Update()
    {
        kills = GameObject.FindGameObjectWithTag("loader").GetComponent<Load>().kills;
        if(kills==numToKill)
        {

            this.gameObject.SetActive(false);
        }
    }
}
