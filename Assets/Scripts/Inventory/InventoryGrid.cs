using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGrid : MonoBehaviour
{
    [SerializeField] private Image _image;

    private string itemName = null;
    
    public string SetItem(string name,Sprite sprite)
    {
        string prevName = itemName;

        itemName = name;
        _image.overrideSprite = sprite;

        if (prevName != null)
        {
            return itemName;
        }
        return null;
    }


}
