using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject actionCue;
    void Start()
    {
        actionCue.SetActive(false);
        Locator.Instance.Player.CanPickUp += HandleCanPickUp;
        Locator.Instance.Player.CannotPickUp += HandleCannotPickUp;
    }

    void HandleCanPickUp()
    {
        actionCue.SetActive(true);
    }

    void HandleCannotPickUp()
    {
        actionCue.SetActive(false);
    }
}
