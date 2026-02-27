using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueManager dialogueManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogueManager.Interact();
        }
    }

}
