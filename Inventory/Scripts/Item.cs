using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IPickupable
{
    public ItemData itemData;
    private LayerMask originalLayer;

    public void Start()
    {
        originalLayer = gameObject.layer;
    }
    public void Pickup()
    {
        Destroy(gameObject);
    }

    public void Outline(bool active)
    {
        if (active)
        {
            gameObject.layer = LayerMask.NameToLayer("Outline");
            foreach (Transform child in transform.GetComponentsInChildren<Transform>())
            {
                transform.gameObject.layer = LayerMask.NameToLayer("Outline");
            }
        }
        else
        {
            gameObject.layer = originalLayer;
            foreach (Transform child in transform.GetComponentsInChildren<Transform>())
            {
                transform.gameObject.layer = originalLayer;
            }
        }
    }
}
