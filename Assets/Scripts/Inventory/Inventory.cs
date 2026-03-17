using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoSingleton<Inventory>
{


    [SerializeField] private float poolReleaseTime = 5.0f;

    public Action<string> PickUpUIUpdate;
    public Action<string> DropItem;
    public Action<int> ScrollMouse;

    private string[] inventorySlots;

    private string[]_inventoryItems = new string[3];

    private int selectedSlot = 0;

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

        ItemPool.Instance.Init(poolReleaseTime);
        inventorySlots = new string[3];
    }


    void Update()
    {

    }

    private void OnPickUp(string name)
    {

        PickUpUIUpdate(name);
        OnDrop();
        _inventoryItems[selectedSlot] = name;


        if (_inventoryItems[selectedSlot] == null)
        {
            PickUpUIUpdate(selectedSlot.ToString());
        }
        else
        {
            PickUpUIUpdate(_inventoryItems[selectedSlot]);
        }

    }

    public GameObject OnDrop()
    {
        string name = null;
        if (_inventoryItems[selectedSlot] != null)
            name = _inventoryItems[selectedSlot];
        else
            return null;

        Debug.Log("Drop" + name);
        var item = ItemPool.Instance.Spawn(name);
        if (item == null)
        {
            var pre = Resources.Load<GameObject>("Prefabs/" + name);
            item = Instantiate(pre);
        }
        var trans = item.GetComponent<Transform>();
        trans.position = PlayerController.Instance.dropBox.position;

        _inventoryItems[selectedSlot] = null;


        if (_inventoryItems[selectedSlot] == null)
        {
            PickUpUIUpdate(selectedSlot.ToString());
        }
        else
        {
            PickUpUIUpdate(_inventoryItems[selectedSlot]);
        }
        return item as GameObject;

    }
    private void OnMouseScrolled(bool up)
    {
        if (up)
        {
            selectedSlot++;
            if (selectedSlot > inventorySlots.Length - 1)
                selectedSlot = 0;
        }
        else
        {
            selectedSlot--;
            if (selectedSlot < 0)
                selectedSlot = inventorySlots.Length - 1;
        }
        ScrollMouse(selectedSlot);
    }

    public string[] GetInventoryItems()
    {
        return _inventoryItems;
    }

    public bool RemoveInventoryItem(string name)
    {
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            if(inventorySlots[i] == name)
            {
                return true;
            }
        }
        return false;
    }
    public bool AddInventoryItem(string name)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i] == null)
            {
                inventorySlots[i] = name;
                return true;
            }
        }
        return false;

    }
    public string GetSelectedItem()
    {
        return inventorySlots[selectedSlot];
    }

}
