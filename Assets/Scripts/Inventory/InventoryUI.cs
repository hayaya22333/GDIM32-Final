using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InventoryUI : MonoBehaviour
{

    public InventoryGrid[] Slots;

    private int curSlot = 0;

    private void OnEnable()
    {
        Inventory.Instance.PickUpUIUpdate += UIUpdate;
        Inventory.Instance.ScrollMouse += UISlotUpdate;
    }

    private void OnDisable()
    {
        Inventory.Instance.PickUpUIUpdate -= UIUpdate;
        Inventory.Instance.ScrollMouse -= UISlotUpdate;
    }

    private void UIUpdate(string item)
    {
        if (item == null)
            return;

        var sprite = Resources.Load<Sprite>("ItemSprites/"+item);

        string swapItem = Slots[curSlot].SetItem(item, sprite);

        if (swapItem != null)
        {
            Inventory.Instance.OnDrop(swapItem);
        }
    }

    private void UISlotUpdate(int slot)
    {
        curSlot = slot;
        for (int i = 0; i < Slots.Length; i++)
        {
            if (i != curSlot)
            {
                Slots[i].SetSelectedImage(false);
            }
            else
            {
                Slots[i].SetSelectedImage(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
