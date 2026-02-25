using System.Collections;
using System.Collections.Generic;
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
        Locator.Instance.Player.PickUp += HandlePickUp;
    }

    public void HandlePickUp()
    {
        rock.Play();
    }
}
