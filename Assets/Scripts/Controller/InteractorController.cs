using System.Collections;
using System.Collections.Generic;
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
    public float interactDistance = 5f;
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

            if (hitObject.CompareTag("Item"))
            {
                CanPickUp.Invoke("Item");
                
            }else if (hitObject.CompareTag("NPC"))
            {
                CanPickUp.Invoke("NPC");
            }
            else
            {
                CannotPickUp.Invoke();
            }

            if (hit.collider.TryGetComponent<IInteractable>(out var interactable))
            {
                AllowInteract(interactable);
            }

        }
    }

    void AllowInteract(IInteractable interactable)
    {
        if (Input.GetMouseButtonDown(0))
        {
            PickedUp.Invoke(interactable.GetName());
            interactable.Interact();
        }
    }

}