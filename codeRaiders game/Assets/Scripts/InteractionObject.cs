﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    // Start is called before the first frame update

    //??
    public bool inventory;
    public string ItemType = "";
    public void DoInteraction()
    {
        
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
