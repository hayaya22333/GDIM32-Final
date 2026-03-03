using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InventoryUI : MonoBehaviour
{

    public InventoryGrid[] Slots;



    private void OnEnable()
    {
        Inventory.Instance.PickUpUIUpdate += UIUpdate;
    }

    private void OnDisable()
    {
        Inventory.Instance.PickUpUIUpdate -= UIUpdate;
    }

    private void UIUpdate(string item,int selectedSlot)
    {
        if (item == null)
            return;

        var sprite = Resources.Load<Sprite>("ItemSprites/"+item);

        string swapItem = Slots[selectedSlot].SetItem(item, sprite);

        if (swapItem != null)
        {
            Inventory.Instance.OnDrop(swapItem);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
