using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameTagChanger : MonoBehaviour
{
    [SerializeField] private TMP_Text nameTag;

    public void Start()
    {
        FrogmanLocator.Instance.frogman.frogmanTalking += changeNameTagToFrogman;
        GigaToadLocator.Instance.gigatoad.toadTalking += changeNameTagToGigaToad;
    }

    public void changeNameTagToFrogman()
    {
        nameTag.text = "Eric Frogman";
    }

    public void changeNameTagToGigaToad()
    {
        nameTag.text = "Giga Toad";
    }

}
