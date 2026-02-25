using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Item : MonoBehaviour
{

    public virtual string ItemName => "general item";
    public void Start()
    {
        Locator.Instance.Player.PickUp += HandlePickUp;
    }
    public void HandlePickUp()
    {
        Debug.Log("picked up [" + ItemName + "]");
        Destroy(gameObject);
    }

}
