using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public List<ItemData> items = new List<ItemData>();


    public void AddItem(ItemData item)
    {
        // Adds Item from Inventory
        ItemData existingItem = items.Find(i => i == item);

        items.Add(item);
    }

    public bool SearchInventory(ItemData item)
    {
        foreach (ItemData itemInInv in items)
        {
            if (itemInInv == item)
            {
                return true;
            }
        }
        return false;
    }
}
