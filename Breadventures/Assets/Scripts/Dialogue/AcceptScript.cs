using UnityEngine;
using System.Collections;

public class AcceptScript : MonoBehaviour {

    GameObject quest;
    QuestManager questscript;

    void Start()
    {
        quest = GameObject.FindGameObjectWithTag("Quest");
        questscript = quest.GetComponent<QuestManager>();
    }

    void OnMouseDown()
    {
        questscript.AcceptOrDecline(true);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
