using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialogueObject[] fetchQuest;
    [SerializeField] private DialogueObject correct;
    [SerializeField] private DialogueObject wrong;

    public DialogueUI dialogueUI;

    public delegate void interactWithNPC();
    public event interactWithNPC interactEvent;


    public void Interact()
    {
        dialogueUI.showDialogue(fetchQuest[FrogmanLocator.Instance.frogman.desiredItem]);
        interactEvent();
    }

    public void CorrectReaction()
    {
        dialogueUI.showDialogue(correct);
    }

    public void WrongReaction()
    {
        dialogueUI.showDialogue(wrong);
    }
}
