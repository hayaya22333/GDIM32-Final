using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource rock;
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
    }
}
