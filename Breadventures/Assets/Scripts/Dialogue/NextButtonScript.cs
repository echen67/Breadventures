using UnityEngine;
using System.Collections;

public class NextButtonScript : MonoBehaviour {

    public GameObject questManager;
    QuestManager questManagerScript;

    int counter = 0;

    void Start()
    {
        questManager = GameObject.FindGameObjectWithTag("Quest");
        questManagerScript = questManager.GetComponent<QuestManager>();
    }

    void OnMouseDown()
    {
        questManagerScript.DialogueProgression(counter);
        counter++;
    }
}
