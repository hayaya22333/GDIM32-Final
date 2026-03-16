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
        DialogueUILocator.Instance.dialogueUI.showDialogue(dialogue);
    }
}
