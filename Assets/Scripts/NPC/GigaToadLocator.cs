using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GigaToadLocator : MonoBehaviour
{
    public static GigaToadLocator Instance { get; private set; }
    public GigaToadNPC gigatoad { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        GameObject gigatoadObject = GameObject.FindWithTag("NPC2");
        gigatoad = gigatoadObject.GetComponent<GigaToadNPC>();
    }
}
