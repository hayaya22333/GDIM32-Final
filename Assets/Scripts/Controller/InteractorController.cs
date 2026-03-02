using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractorController : MonoBehaviour
{
    public delegate void EmptyDelegate();
    public delegate void StrDelegate(string x);

    // Create delegates
    public event EmptyDelegate CanPickUp;
    public event EmptyDelegate CannotPickUp;
    public event StrDelegate PickedUp;
    
    // Set variables
    public float interactDistance = 10f;
    private Camera cam;

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            if (hit.collider.TryGetComponent<IInteractable>(out var interactable))
            {
                CanPickUp.Invoke();
                if (Input.GetMouseButtonDown(0))
                {
                    interactable.Interact();
                    PickedUp.Invoke(interactable.GetName());
                }
            }
            else
            {
                CannotPickUp.Invoke();
            }
        }
    }
}