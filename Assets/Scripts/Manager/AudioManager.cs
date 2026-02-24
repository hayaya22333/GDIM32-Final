using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, ITF_Interactable
{
    [SerializeField] AudioSource rock;

    public void Interact()
    {
        Debug.Log("picked up the item.");
        Destroy(gameObject);
    }
}
