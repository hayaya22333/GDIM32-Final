using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogmanLocator : MonoBehaviour
{
    public static FrogmanLocator Instance { get; private set; }
    public FrogmanNPC frogman { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        GameObject frogmanObject = GameObject.FindWithTag("NPC");
        frogman = frogmanObject.GetComponent<FrogmanNPC>();
    }
}
