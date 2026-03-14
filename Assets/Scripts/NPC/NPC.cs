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

    [SerializeField] private AudioSource music;

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
                animator.SetInteger("EricState", 0);
                TalkTo();
                break;
            case NpcState.Talking:
                animator.SetInteger("EricState", 1);
                break;
        }
        //transform.Rotate(rotationSpeed * Time.deltaTime);
    }

    void TalkTo()
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

}
