using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ITF_Interactable
{
    public void Interact();
}
public class InteractorController : MonoBehaviour
{
    public Transform player_Cam;
    public float interactRange;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray r = new Ray(player_Cam.position, player_Cam.forward);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out ITF_Interactable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }
}
