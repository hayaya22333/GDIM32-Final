using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueUILocator : MonoBehaviour
{
    public static DialogueUILocator Instance { get; private set; }
    public DialogueUI dialogueUI { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        GameObject dialogueUIobj = GameObject.FindWithTag("UI");
        dialogueUI = dialogueUIobj.GetComponent<DialogueUI>();
    }
}
