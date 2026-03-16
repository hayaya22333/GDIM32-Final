using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogmanDialogueManager : DialogueManager
{
    [SerializeField] private DialogueObject[] fetchQuest;
    [SerializeField] private DialogueObject correct;
    [SerializeField] private DialogueObject wrong;

    public delegate void interactWithNPC();
    public event interactWithNPC interactEvent;

    public override void Intro()
    {
        base.Intro();
        Debug.Log(FrogmanLocator.Instance.frogman);
    }

    public virtual void Interact()
    {
        interactEvent();
        base.Interact();
    }

    public override void showDialogue()
    {
        int desiredItemID = FrogmanLocator.Instance.frogman.desiredItem;
        DialogueUILocator.Instance.dialogueUI.showDialogue(fetchQuest[desiredItemID]);
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
