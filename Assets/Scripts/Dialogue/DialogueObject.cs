using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [SerializeField][TextArea] private string[] dialogue;
    public string[] Dialogue => dialogue;

    [SerializeField] private Response[] responses;

    public bool HasResponses => Responses != null && Responses.Length > 0;

    public Response[] Responses => responses;
}

