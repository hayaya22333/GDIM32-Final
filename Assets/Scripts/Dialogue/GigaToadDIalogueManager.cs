using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GigaToadDIalogueManager : DialogueManager
{
    [SerializeField] private DialogueObject dialogue;

    public override void Intro()
    {
        base.Intro();
    }

    public override void showDialogue()
    {
        if (TryGetComponent(out DialogueResponseEvent responseEvents) && responseEvents.DialogueObject == dialogue)
        {
            DialogueUILocator.Instance.dialogueUI.AddResponseEvents(responseEvents.Events);
        }
        Debug.Log(responseEvents);
        DialogueUILocator.Instance.dialogueUI.showDialogue(dialogue);
    }
}
