using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[10];
    public Button[] InventoryButtons = new Button[10];
    public void AddItem(GameObject item)
    {
        bool itemAdded = false;//bool to see if item can be added or not
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)//if inventory isn't full
            {
                inventory[i] = item;//add item to inventory
                InventoryButtons[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;//adds sprite to the item
                Debug.Log(item.name + "was added");
                itemAdded = true;//item added to inventory is true
                item.SendMessage("DoInteraction");
                break;
            }
        }
        if (!itemAdded)//if item wasn't added is because inventory  is full
        {
            Debug.Log("Inventory full");
        }

    }
    public bool FindItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                return true;
            }
        }
        return false;
    }

    public GameObject FindItemByType(string itemType)//searches the item by type so if it's healthpotion then it'll find the health prefab
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                if (inventory[i].GetComponent<InteractionObject>().ItemType == itemType)//if the string that it selects is equal to the string of the prefab
                {
                    return inventory[i];//if itemtype is equal to the paramter then give the value of that inventory item
                }
            }
        }
        return null;
    }
    public void RemoveItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)//if the item is found from the array slot
            {
                inventory[i] = null;
                Debug.Log(item.name + " Removed");
                InventoryButtons[i].image.overrideSprite = null;
                break;
            }

        }
    }

}