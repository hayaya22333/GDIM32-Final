using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private DialogueObject speechDialogue;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private Button closeBoxButton;

    [Header("References")]
    [SerializeField] private DialogueTyper typer;

    public delegate void closeDialogue();
    public event closeDialogue endTalkEvent;


    public void Start()
    {
        dialogueBox.SetActive(false);
        dialogueText.text = string.Empty;
        closeBoxButton.gameObject.SetActive(false);
    }

    public void showDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        dialogueText.text = string.Empty;
        StartCoroutine(routine: RunDialogue(dialogueObject));
        closeBoxButton.gameObject.SetActive(false);
    }
    private IEnumerator RunDialogue(DialogueObject dialogueObject)
    {
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typer.RunTyper(dialogue, dialogueText);

            if (i == dialogueObject.Dialogue.Length - 1)
            {
                closeBoxButton.gameObject.SetActive(true);
                break;
            }

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        }


    }
    public void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        dialogueText.text = string.Empty;
        endTalkEvent();
    }
}
