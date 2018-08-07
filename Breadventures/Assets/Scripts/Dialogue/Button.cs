using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public int ID;
    GameObject questManager;
    QuestManager questScript;
    public string questTitle;

    void Start()
    {
        questManager = GameObject.FindGameObjectWithTag("Quest");
        questScript = questManager.GetComponent<QuestManager>();
    }

    public void OnMouseDown()
    {
        questScript.QuestDialogue(questTitle);
    }
}
