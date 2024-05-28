using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Inventory playerInventory;
    private UIHandler UI;
    private GameObject currentInteractable = null;

    [SerializeField] private float raycastDistance = 3f;

    void Start()
    {
        playerInventory = GetComponent<Inventory>();
        UI = GetComponentInChildren<UIHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        InteractionUI();
    }

    private void InteractionUI()
    {
        // Check for the raycast hit without pressing the key to show the interaction text
        Ray rayForText = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitForUI;

        if (Physics.Raycast(rayForText, out hitForUI, raycastDistance))
        {
            // Check if the hit object has a script with the ItemPickup component
            IPickupable pickupable = hitForUI.collider.GetComponent<IPickupable>();
            IInteractable interactable = hitForUI.collider.GetComponent<IInteractable>();

            // Ray hit pick up item
            if (pickupable != null)
            {
                // Enable text
                UI.PickupText(true, hitForUI.collider.GetComponent<Item>().itemData.Icon);

                //Enable Outline and save game object
                currentInteractable = hitForUI.collider.gameObject;
                Outline(true);

            }
            // Ray hit interactable
            else if (interactable != null)
            {
                // Enable text
                UI.InteractText(true);

                //Enable Outline and save game object
                currentInteractable = hitForUI.collider.gameObject;
                Outline(true);
            }
            // Ray hit non interactable
            else
            {
                UI.HideInteractiveText();
                Outline(false);
            }
        }
        // Ray hit nothing
        else
        {
            UI.HideInteractiveText();
            Outline(false);
        }
    }

    public void Interact()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            // Pickup able object
            IPickupable pickupable = hit.collider.GetComponent<IPickupable>();
            if (pickupable != null)
            {
                pickupable.Pickup();

                ItemData item = hit.collider.GetComponent<Item>().itemData;
                if (item != null)
                {
                    PickUpItem(item);
                }
            }

            // InteractableObject
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }

        }
    }

    public void PickUpItem(ItemData item)
    {
        playerInventory.AddItem(item);
    }

    private void Outline(bool active)
    {
        if (active)
        {
            if (currentInteractable.GetComponent<IInteractable>() != null) { currentInteractable.GetComponent<IInteractable>().Outline(true); }
            if (currentInteractable.GetComponent<IPickupable>() != null) { currentInteractable.GetComponent<IPickupable>().Outline(true); }
        }
        else
        {
            if (currentInteractable.GetComponent<IInteractable>() != null) { currentInteractable.GetComponent<IInteractable>().Outline(false); }
            if (currentInteractable.GetComponent<IPickupable>() != null) { currentInteractable.GetComponent<IPickupable>().Outline(false); }
        }
    }
}
