using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unload : MonoBehaviour
{
    public int scene;
    public bool unloaded;
    public bool newLoaded;
    void Start()
    {
        newLoaded = GameObject.FindGameObjectWithTag("loader").GetComponent<Load>().loaded;
    }
    void Update()
    {
        newLoaded = GameObject.FindGameObjectWithTag("loader").GetComponent<Load>().loaded;
        if (newLoaded)
        {
            unloaded = true;
            AnyManager.anyManager.UnloadScene(scene);
        }
    }
}
