using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {


    //private List<>

    [SerializeField] private float poolReleaseTime = 10.0f;

    public static Action<string> PickUpUIUpdate;

    private void OnEnable()
    {
        Locator.Instance.Player.PickedUp += OnPickUp;
    }
    private void OnDisable()
    {
        Locator.Instance.Player.PickedUp -= OnPickUp;
    }

    void Start()
    {
        ItemPool.Instance.Init(poolReleaseTime);


    }


    void Update()
    {
        
    }

    private void OnPickUp(string name)
    {
        PickUpUIUpdate(name);

    }
}
