using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public bool saidIntro;

    public enum NpcState { Idle, Talking }
    public NpcState currentState;

    [SerializeField] private AudioSource music;

    public virtual void Start()
    {
        currentState = NpcState.Idle;

        DialogueUILocator.Instance.dialogueUI.endTalkEvent += changeToIdle;
    }

    

    public void TalkTo()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            currentState = NpcState.Talking;
            if (saidIntro == false)
            {
                dialogueManager.Intro();
                saidIntro = true;
                music.Play();
            }
            else if (saidIntro == true)
            {
                dialogueManager.Interact();
            }
        }
    }

    public void changeToIdle()
    {
        currentState = NpcState.Idle;
    }

    public NpcState GetState()
    {
        return this.currentState;
    }

    public virtual void OnCollisionEnter(Collision other)
    {
        
    }

}
