using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoSingleton<Inventory> {


    [SerializeField] private float poolReleaseTime = 5.0f;

    public Action<string,int> PickUpUIUpdate;

    public Action<string> DropItem;

    private string[] inventorySlots;

    private List<string> _inventoryItems;

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

        ItemPool.Instance.Init(poolReleaseTime);
        inventorySlots = new string[3];
    }


    void Update()
    {
        
    }

    private void OnPickUp(string name)
    {

        PickUpUIUpdate(name, selectedSlot);
        _inventoryItems.Add(name);

    }

    public void OnDrop(string name)
    {
        Debug.Log("Drop" + name);
        var item = ItemPool.Instance.Spawn(name);
        if(item == null)
        {
            var pre = Resources.Load<GameObject>("Prefabs/" + name);
            item = Instantiate(pre);
        }
        var trans = item.GetComponent<Transform>();
        trans.position = this.transform.position;

        _inventoryItems.Remove(name);
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
        Debug.Log(selectedSlot);

    }

    public List<string> GetInventoryItems()
    {
        return _inventoryItems;
    }

    public bool RemoveInventoryItem(string name)
    {
        if (_inventoryItems.Contains(name))
        {
            _inventoryItems.Remove(name);
            return true;
        }
        return false;
    }
    public bool AddInventoryItem(string name)
    {
        for (int i = 0;i<inventorySlots.Length;i++)
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
