using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogmanNPC : NPC
{
    public int desiredItem;
    public string[] listOfItems;

    private void Start()
    {
        dialogueManager.interactEvent += SelectDesiredItem;
    }

    private void SelectDesiredItem()
    {
        desiredItem = Random.Range(0, listOfItems.Length);
    }
}
