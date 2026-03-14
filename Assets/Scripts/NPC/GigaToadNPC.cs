using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GigaToadNPC : NPC
{
    public GameObject[] listOfItems;
    public Transform spawnLocation;

    public override void Start()
    {
        base.Start();
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
