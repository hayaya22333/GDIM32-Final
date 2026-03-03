using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoSingleton<Inventory> {


    [SerializeField] private float poolReleaseTime = 10.0f;

    public Action<string,int> PickUpUIUpdate;

    public Action<string> DropItem;

    private string[] inventorySlots;

    private int selectedSlot;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        Locator.Instance.Player.PickedUp -= OnPickUp;
        PlayerController.Instance.MouseScrolled -= OnMouseScrolled;
    }

    void Start()
    {
        Locator.Instance.Player.PickedUp += OnPickUp;
        PlayerController.Instance.MouseScrolled += OnMouseScrolled;

        ItemPool.Instance.Init();
        inventorySlots = new string[3];
    }


    void Update()
    {
        
    }

    private void OnPickUp(string name)
    {
   
        PickUpUIUpdate(name,selectedSlot);

    }

    public void OnDrop(string name)
    {
        Debug.Log("Drop" + name);
        var item = ItemPool.Instance.Spawn(name);
        if(item == null)
        {
            item = Resources.Load<GameObject>("Prefabs/" + item);
            Instantiate(item);
        }
        var trans = item.GetComponent<Transform>(); 
        trans.position = this.transform.position;

    }
    private void OnMouseScrolled(bool up)
    {
        if (up)
        {
            selectedSlot++;
            if (selectedSlot > inventorySlots.Length-1)
                selectedSlot = 0;
        }
        else
        {
            selectedSlot--;
            if (selectedSlot < 0)
                selectedSlot = inventorySlots.Length - 1;
        }
        Debug.Log(selectedSlot);

    }

}
