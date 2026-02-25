using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rock : Item, ITF_Interactable
{
    [SerializeField] AudioSource rock;
    public override void Interact()
    {
        base.Interact();
        rock.Play();
        Destroy(gameObject);
    }
}
