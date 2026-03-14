using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject actionCue;
    void Start()
    {
        actionCue.SetActive(false);
        Locator.Instance.Player.CanPickUp += HandleCanPickUp;
        Locator.Instance.Player.CannotPickUp += HandleCannotPickUp;
    }

    void HandleCanPickUp(string tag)
    {
        actionCue.SetActive(true);
        if (tag == "Item")
        {
            actionCue.GetComponent<TMP_Text>().text = "[LMB] pick up";
        } else if (tag == "NPC")
        {
            actionCue.GetComponent<TMP_Text>().text = "[F] talk";
        }
    }

    void HandleCannotPickUp()
    {
        actionCue.SetActive(false);
    }
}
