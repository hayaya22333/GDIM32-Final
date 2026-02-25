using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractorController : MonoBehaviour
{
    public delegate void EmptyDelegate();
    public delegate void StrDelegate();
    //public event EmptyDelegate Interact;
    //public event StrDelegate UniqueInteract;
    public float interactDistance = 10f;
    private Camera cam;

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                ITF_Interactable interactable = hit.collider.GetComponent<ITF_Interactable>();

                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
    }
}