using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogmanNPC : NPC
{
    public int desiredItem;
    public string[] listOfItems;
    public bool gaveRequest;

    public override void Start()
    {
        base.Start();

        dialogueManager.interactEvent += SelectDesiredItem;
        gaveRequest = false;
    }

    private void SelectDesiredItem()
    {
        if (gaveRequest == false)
        {
            desiredItem = Random.Range(0, listOfItems.Length);
            gaveRequest = true;
        }
    }
}
