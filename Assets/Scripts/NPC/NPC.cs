using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public bool saidIntro;

    public enum NpcState { Idle, Talking }
    public NpcState currentState;

    public AudioSource music;

    public Transform PlayerRefer;
    public float minDistanceTalk = 5;

    public virtual void Start()
    {
        currentState = NpcState.Idle;

        DialogueUILocator.Instance.dialogueUI.endTalkEvent += changeToIdle;

        PlayerRefer = PlayerController.Instance.gameObject.transform;

    }



    public virtual void TalkTo()
    {
        
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
