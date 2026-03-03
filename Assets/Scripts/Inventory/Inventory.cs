using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoSingleton<Inventory> {


    [SerializeField] private float poolReleaseTime = 10.0f;

    public Action<string,int> PickUpUIUpdate;

    public Action<string> DropItem;

    private string[] inventorySlots;

    private int selectedSlot;

    private void OnEnable()
    {
        Locator.Instance.Player.PickedUp += OnPickUp;
        PlayerController.Instance.MouseScrolled += OnMouseScrolled;
    }

    private void OnDisable()
    {
        Locator.Instance.Player.PickedUp -= OnPickUp;
        PlayerController.Instance.MouseScrolled -= OnMouseScrolled;
    }

    void Start()
    {
        ItemPool.Instance.Init(poolReleaseTime);
        inventorySlots = new string[3];
    }


    void Update()
    {
        
    }

    private void OnPickUp(string name)
    {
        for(int i = 0;i<inventorySlots.Length;i++)
        {
            if (inventorySlots[i] != null)
            {
                DropItem(inventorySlots[i]);
            }
            inventorySlots[i] = name;
        }

        PickUpUIUpdate(name,selectedSlot);

    }
    private void OnMouseScrolled(bool up)
    {
        if (up)
        {
            selectedSlot++;
            if (selectedSlot > inventorySlots.Length)
                selectedSlot = 0;
        }
        else
        {
            selectedSlot--;
            if (selectedSlot < 0)
                selectedSlot = inventorySlots.Length - 1;
        }

    }

}
