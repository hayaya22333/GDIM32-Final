using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGrid : MonoBehaviour
{
    [SerializeField] private Image _image;

    private string itemName = null;

    private void Awake()
    {
        _image = this.GetComponent<Image>();
    }

    public string SetItem(string name,Sprite sprite)
    {
        string prevName = new string(itemName);
        if (itemName == null)
        {
            prevName = null;
        }
        
        itemName = name;
        _image.overrideSprite = sprite;

        if (prevName != null)
        {
            return prevName;
        }
        return null;
    }


}
