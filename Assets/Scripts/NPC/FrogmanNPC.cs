using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogmanNPC : NPC
{
    public int desiredItem;
    public string[] listOfItems;
    public bool gaveRequest;
    Animator animator;

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
                TalkTo();
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


    public override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Debug.Log("item collected");
            Item collectedItem = other.gameObject.GetComponent<Item>();

            if (collectedItem.itemID == desiredItem)
            {
                dialogueManager.CorrectReaction();
                gaveRequest = false;
            }
            else
            {
                dialogueManager.WrongReaction();
            }
        }
    }
}
