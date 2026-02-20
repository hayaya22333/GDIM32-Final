using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueTyper : MonoBehaviour
{
    [SerializeField] private float typingSpeed;

    public Coroutine RunTyper(string dialogueText, TMP_Text textLabel)
    {
        return StartCoroutine(routine: TypeText(dialogueText, textLabel));
    }

    private IEnumerator TypeText(string dialogueText, TMP_Text textLabel)
    {
        textLabel.text = string.Empty;

        float timer = 0;
        int charIndex = 0;

        while (charIndex < dialogueText.Length)
        {
            timer += Time.deltaTime * typingSpeed;
            charIndex = Mathf.FloorToInt(timer);
            charIndex = Mathf.Clamp(value: charIndex, 0, dialogueText.Length);

            textLabel.text = dialogueText.Substring(0, charIndex);

            yield return null;
        }

        textLabel.text = dialogueText;
    }
}
