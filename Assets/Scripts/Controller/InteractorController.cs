using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractorController : MonoBehaviour
{
    // Set delegate types
    public delegate void EmptyDelegate();
    public delegate void StrDelegate(string x);

    // Create delegates
    public event StrDelegate PickedUp;
    
    // Set variables
    public float interactDistance = 10f;
    private Camera cam;

    // Functions
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            if (hit.collider.TryGetComponent<IInteractable>(out var interactable))
            {
                interactable.Interact();
                PickedUp.Invoke(interactable.GetName());
            }
        }
    }

}