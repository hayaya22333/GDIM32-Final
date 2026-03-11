using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Response : MonoBehaviour
{
    [SerializeField] private string responseText;
    [SerializeField] private DialogueObject dialogueObject;
    public Sprite customerExpression;

    public string ResponseText => responseText;

    public DialogueObject DialogueObject => dialogueObject;
}
