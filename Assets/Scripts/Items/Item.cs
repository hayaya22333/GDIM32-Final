using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ITF_Interactable
{
    public virtual void Interact()
    {
        Debug.Log("picked up the item.");
    }
}
