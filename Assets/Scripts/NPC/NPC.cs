using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Vector3 rotationSpeed = new Vector3(0, 50, 0);
    public bool saidIntro;
    Animator animator;


    public enum NpcState { Idle, Talking }
    public NpcState currentState;

    public virtual void Start()
    {
        animator = GetComponentInChildren<Animator>();
        currentState = NpcState.Idle;

        DialogueUILocator.Instance.dialogueUI.endTalkEvent += changeToIdle;
    }

    private void Update()
    {
        switch (currentState)
        {
            case NpcState.Idle:
                TalkTo();
                break;
            case NpcState.Talking:
                break;
        }
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }

    void TalkTo()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetInteger("EricState", 1);
            currentState = NpcState.Talking;
            if (saidIntro == false)
            {
                dialogueManager.Intro();
                saidIntro = true;
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

}
