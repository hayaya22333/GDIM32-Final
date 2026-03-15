using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private TMP_Text QuestText;
    public string[] quests;

    private void Start()
    {
        FrogmanLocator.Instance.frogman.questEvent += UpdateQuest;
    }

    private void UpdateQuest()
    {
        QuestText.text = quests[FrogmanLocator.Instance.frogman.desiredItem];
    }
}
