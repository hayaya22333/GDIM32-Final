using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogmanLocator : MonoBehaviour
{
    public static FrogmanLocator Instance { get; private set; }
    public FrogmanNPC frogman { get; private set; }
    public FrogmanShooter shooter { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        GameObject frogmanObject = GameObject.FindWithTag("NPC");
        GameObject shooterObject = GameObject.FindWithTag("Shooter");
        frogman = frogmanObject.GetComponent<FrogmanNPC>();
        shooter = shooterObject.GetComponent<FrogmanShooter>();

        Debug.Log(frogmanObject);
    }
}
