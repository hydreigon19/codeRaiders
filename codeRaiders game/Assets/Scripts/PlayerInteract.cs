using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject currentInterObj = null;
    public InteractionObject currentInterObjScript=null;
    public Inventory inventory2;
    void Update()
    {
        /*
         if(currentInterObj)
        {
            //check if object is to be stored in the inventory
            currentInterObj.SendMessage("DoInteraction");
         
        }
         */
        if (currentInterObj)//if the objects exist
        {
            if (currentInterObjScript.inventory)//if it is one then add to invetnory
            {
                inventory2.AddItem(currentInterObj);
                Debug.Log("Item Added ");
            }
         
        }
        if(Input.GetKey("1"))//if user presses 1 and the there is an item of health potion
        {
            GameObject healthp = inventory2.FindItemByType("HealthPotion");
            if(healthp !=null)//potion found
            {
                this.GetComponent<Health>().SetHealth(6);//set user health 
                Debug.Log(" " + healthp.name);
                inventory2.RemoveItem(healthp);//remove item from inventory
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("interObject"))
        {
            
          //  this.gameObject.GetComponent<Health>().getHealth();
            //stores what ever the object is
            currentInterObj = other.gameObject;//store object
            Debug.Log("Object found");
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();//link interaction object script
            //this.gameObject.GetComponent<Health>().SetHealth(6);
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
