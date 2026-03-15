using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialogueObject intro;


    public virtual void Intro()
    {
        DialogueUILocator.Instance.dialogueUI.showDialogue(intro);
    }

    public virtual void Interact()
    {
        Invoke("showDialogue", 1);
    }

    public virtual void showDialogue()
    {
        
    }

    
}
