using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject currentInterObj = null;

    void Update()
    {
        if(currentInterObj)
        {
            currentInterObj.SendMessage("DoInteraction");
         
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("interObject"))
        {
            this.gameObject.GetComponent<Health>().getHealth();
            currentInterObj = other.gameObject;//stores what ever the object is
            this.gameObject.GetComponent<Health>().SetHealth(6);
        }
       
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("interObject"))
        {
            if(other.gameObject==currentInterObj)
            {
                currentInterObj = null;
               
            }
           
            Debug.Log("Exit");
           
        }
    }
}
