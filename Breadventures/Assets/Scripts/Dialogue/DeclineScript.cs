using UnityEngine;
using System.Collections;

public class DeclineScript : MonoBehaviour {

    GameObject quest;
    QuestManager questscript;

    void Start()
    {
        quest = GameObject.FindGameObjectWithTag("Quest");
        questscript = quest.GetComponent<QuestManager>();
    }

    void OnMouseDown()
    {
        questscript.AcceptOrDecline(false);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
