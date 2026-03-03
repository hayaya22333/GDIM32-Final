using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{



    private void OnEnable()
    {
        Inventory.PickUpUIUpdate += UIUpdate;
    }

    private void UIUpdate(string obj)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
