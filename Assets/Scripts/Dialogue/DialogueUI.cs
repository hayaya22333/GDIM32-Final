using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private DialogueObject speechDialogue;
    [SerializeField] private GameObject dialogueBox;

    [Header("References")]
    [SerializeField] private DialogueTyper typer;

    public void showDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        dialogueText.text = string.Empty;
        StartCoroutine(routine: RunDialogue(dialogueObject));
    }
    private IEnumerator RunDialogue(DialogueObject dialogueObject)
    {
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typer.RunTyper(dialogue, dialogueText);

            if (i == dialogueObject.Dialogue.Length - 1)
            {
                break;
            }

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            CloseDialogueBox();
        }

    }
    public void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        dialogueText.text = string.Empty;
    }
}
