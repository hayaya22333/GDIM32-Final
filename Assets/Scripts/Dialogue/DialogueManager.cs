using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialogueObject[] fetchQuest;
    [SerializeField] private DialogueObject correct;
    [SerializeField] private DialogueObject wrong;

    public DialogueUI dialogueUI;

    public void Interact()
    {
        int randomQuest = Random.Range(0, fetchQuest.Length);
        dialogueUI.showDialogue(fetchQuest[randomQuest]);
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
