using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ITF_Interactable
{
    public void Interact()
    {
        Debug.Log("picked up the item.");
    }
}
