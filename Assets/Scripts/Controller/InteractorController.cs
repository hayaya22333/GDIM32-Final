using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractorController : MonoBehaviour
{
    // Set delegate types
    public delegate void EmptyDelegate();
    //public delegate void StrDelegate(string x);

    // Create delegates
    public event EmptyDelegate PickUp;
    //public event StrDelegate GotPicked;
    
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
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.collider.CompareTag("Item"))
                {
                    PickUp.Invoke();
                }
            }
        }
    }

}