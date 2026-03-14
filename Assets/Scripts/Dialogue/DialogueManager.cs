using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialogueObject intro;
    [SerializeField] private DialogueObject[] fetchQuest;
    [SerializeField] private DialogueObject correct;
    [SerializeField] private DialogueObject wrong;

    public delegate void interactWithNPC();
    public event interactWithNPC interactEvent;

    public void Intro()
    {
        DialogueUILocator.Instance.dialogueUI.showDialogue(intro);
        Debug.Log(FrogmanLocator.Instance.frogman);
    }

    public void Interact()
    {
        interactEvent();
        Invoke("showDialogue", 1);
    }

    void showDialogue()
    {
        int desiredItemID = FrogmanLocator.Instance.frogman.desiredItem;
        DialogueUILocator.Instance.dialogueUI.showDialogue(fetchQuest[1]);
    }

    public void CorrectReaction()
    {
        DialogueUILocator.Instance.dialogueUI.showDialogue(correct);
    }

    public void WrongReaction()
    {
        DialogueUILocator.Instance.dialogueUI.showDialogue(wrong);
    }
}
