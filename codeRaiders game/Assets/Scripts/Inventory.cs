using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory;
    public Button[] InventoryButtons;
    public int[] itemCount;
    public bool[] hasItem;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (itemCount[0] > 0)
            {
                this.GetComponent<Health>().SetHealth(6);//set user health 
                itemCount[0] -= 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (itemCount[1] > 0)
            {
                this.GetComponent<Health>().SetArmor(6);//set user armor 
                itemCount[1] -= 1;
            }
        }
        if (itemCount[0] == 0)
        {
            hasItem[0] = false;
            InventoryButtons[0].image.overrideSprite = null;
        }
        if (itemCount[1] == 0)
        {
            hasItem[1] = false;
            InventoryButtons[1].image.overrideSprite = null;
        }
    }
    public void AddItem(GameObject item)
    {
        if (item.CompareTag("healthPotion"))
        {
            if(hasItem[0]==false)
            {
                inventory[0] = item;//add item to inventory
                InventoryButtons[0].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;//adds sprite to the item
                itemCount[0] += 1;
                hasItem[0] = true;
                Debug.Log(item.name + "was added");
                Destroy(item);
            }
            else
            {
                itemCount[0] += 1;
                Destroy(item);
            }
   
        }
        if (item.CompareTag("armorPotion"))
        {
            if (hasItem[1] == false)
            {
                inventory[1] = item;//add item to inventory
                InventoryButtons[1].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;//adds sprite to the item
                itemCount[1] += 1;
                hasItem[1] = true;
                Debug.Log(item.name + "was added");
                Destroy(item);
            }
            else
            {
                itemCount[1] += 1;
                Destroy(item);
            }

        }

    } 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("healthPotion"))
        {

            AddItem(other.gameObject);
        }
        if (other.CompareTag("armorPotion"))
        {

            AddItem(other.gameObject);
        }
    }

}