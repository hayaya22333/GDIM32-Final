using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogmanNPC : NPC, IInteractable
{
    public int desiredItem;
    public string[] listOfItems;
    public bool gaveRequest;
    Animator animator;
    public FrogmanDialogueManager dialogueManager;

    public delegate void talkingToFrogman();
    public event talkingToFrogman frogmanTalking;

    public delegate void QuestGiven();
    public event QuestGiven questEvent;
    public PlayerController playerController;



    public override void Start()
    {
        base.Start();

        animator = GetComponentInChildren<Animator>();

        dialogueManager.interactEvent += SelectDesiredItem;
        gaveRequest = false;
    }

    private void Update()
    {
        switch (currentState)
        {
            case NpcState.Idle:
                animator.SetInteger("EricState", 0);
                break;
            case NpcState.Talking:
                animator.SetInteger("EricState", 1);
                break;
        }
    }

    private void SelectDesiredItem()
    {
        if (gaveRequest == false)
        {
            desiredItem = Random.Range(0, listOfItems.Length);
            gaveRequest = true;
        }
    }

    public void Interact()
    {
        if (currentState == NpcState.Idle){
            TalkTo();
        }
    }


    public string GetName()
    {
        return name;
    }


    public string GetInteractableType()
    {
        return "NPC";
    }


    public override void TalkTo()
    {

        //float distance = Vector3.Distance(PlayerRefer.position, this.transform.position);
        //if (distance > minDistanceTalk)
        //    return;
        currentState = NpcState.Talking;
        frogmanTalking();
        playerController.SetInConversation(true);
        if (saidIntro == false)
        {
            dialogueManager.Intro();
            saidIntro = true;
            music.Play();
        }
        else if (saidIntro == true)
        {
            music.Play();
            dialogueManager.Interact();
            questEvent();
        }

    }

    public override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            music.Play();
            Debug.Log("item collected");
            Item collectedItem = other.gameObject.GetComponent<Item>();

            if (collectedItem.itemID == desiredItem)
            {
                dialogueManager.CorrectReaction();
                gaveRequest = false;
                Destroy(other.gameObject);
            }
            else
            {
                dialogueManager.WrongReaction();
            }
        }
    }


}
