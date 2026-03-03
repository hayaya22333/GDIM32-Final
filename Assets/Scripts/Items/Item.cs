using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{

    public virtual string ItemName => "general item";
    public void Interact()
    {
        Debug.Log("picked up [" + ItemName + "]");

        if(ItemPool.Instance != null)
            ItemPool.Instance.UnSpawn(this.gameObject,ItemName);

    }

    public string GetName()
    {
        return ItemName;
    }

}
