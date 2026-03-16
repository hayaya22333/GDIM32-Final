using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GigaToadNPC : NPC, IInteractable
{
    public GameObject[] listOfItems;
    public Transform spawnLocation;
    public GigaToadDIalogueManager dialogueManager;
    public PlayerController playerController;

    public delegate void talkingToToad();
    public event talkingToToad toadTalking;

    public override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        switch (currentState)
        {
            case NpcState.Idle:
                break;
            case NpcState.Talking:
                break;
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
        //float distance = Vector3.Distance(PlayerRefer.position, transform.position);
        //if (distance > minDistanceTalk)
        //    return;
        currentState = NpcState.Talking;
        toadTalking();

        playerController.SetInConversation(true);
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

    public override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Destroy(other.gameObject);

            int randomItem = Random.Range(0, listOfItems.Length);
            Instantiate(listOfItems[randomItem], spawnLocation.position, Quaternion.identity);
        }
    }
}
