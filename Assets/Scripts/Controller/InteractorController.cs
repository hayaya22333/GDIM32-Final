using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractorController : MonoBehaviour
{
    // Set delegate types
    public delegate void EmptyDelegate();
    public delegate void StrDelegate(string x);

    // Create delegates
    public event StrDelegate CanPickUp;
    public event EmptyDelegate CannotPickUp;
    public event StrDelegate PickedUp;
    
    // Set variables
    public float interactDistance = 8f;
    private Camera cam;

    // Functions
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, interactDistance))
        {
            GameObject hitObject = hit.collider.gameObject;

            switch (hitObject.tag)
            {
                case "Item":
                    CanPickUp.Invoke("Item");
                    break;

                case "NPC":
                case "NPC2":
                    CanPickUp.Invoke("NPC");
                    break;

                default:
                    CannotPickUp.Invoke();
                    break;
            }

            if (hit.collider.TryGetComponent<IInteractable>(out var interactable))
            {
                AllowInteract(interactable);
            }

        }
    }

    void AllowInteract(IInteractable interactable)
    {
        if (Input.GetMouseButtonDown(0) && interactable.GetInteractableType() == "Item")
        {
            PickedUp.Invoke(interactable.GetName());
            interactable.Interact();
        }else if(Input.GetKeyDown(KeyCode.F) && interactable.GetInteractableType() == "NPC")
        {
            interactable.Interact();
        }
    }

}