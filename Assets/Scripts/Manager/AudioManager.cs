using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource rock;
    [SerializeField] AudioSource duck;
    [SerializeField] AudioSource flower;
    [SerializeField] AudioSource bigmac;
    [SerializeField] AudioSource stick;

    public void Start()
    {
        Locator.Instance.Player.PickedUp += HandlePickedUp;
    }

    public void HandlePickedUp(string itemName)
    {
        if (itemName == "rock")
        {
            rock.Play();
        }
        else if (itemName == "duck")
        {
            duck.Play();
        }
        else if (itemName == "stick")
        {
            stick.Play();
        }
        else if (itemName == "flower")
        {
            flower.Play();
        }
        else if (itemName == "bigmac")
        {
            bigmac.Play();
        }
    }
}
