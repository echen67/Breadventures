using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class NPC : MonoBehaviour {

    [Header("Fill this out")]
    public string defaultText;
    public string giverName;
    public string accepted;
    public string declined;

    public GameObject questPrefab;  //drag in inspector

    public Quest firstQuest = new Quest();
    public Quest secondQuest = new Quest();
    private Queue<Quest> questList;

    public GameObject QuestManager;
    QuestManager QuestManagerScript;

    private GameObject GameManager;
    private CursorScript cursorScript;
    private CanvasGroup dialoguePanel;
    private GameObject dialogueContent;

    void Start()
    {
        //QuestManagerScript = QuestManager.GetComponent<QuestManager>();
        GameManager = GameObject.FindGameObjectWithTag("Scene");
        cursorScript = GameManager.GetComponent<CursorScript>();
        dialoguePanel = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<CanvasGroup>();
        dialogueContent = GameObject.FindGameObjectWithTag("DialogueContent");
        
    }

    //for the first display block
    public void OnMouseDown()
    {
        //QuestManagerScript.DisplayText(defaultText, giverName);
        //QuestManagerScript.accepted = accepted;
        //QuestManagerScript.declined = declined;
        cursorScript.SpeechCursor();
        dialoguePanel.GetComponentInChildren<Text>().text = defaultText;
        dialoguePanel.alpha = 1;
        dialoguePanel.interactable = true;
        dialoguePanel.blocksRaycasts = true;

        questList.Enqueue(firstQuest);
        questList.Enqueue(secondQuest);
        foreach (Quest q in questList)
        {
            if (q.questState != Quest.State.Unavailable)
            {
                GameObject instance = Instantiate(questPrefab) as GameObject;
                instance.transform.SetParent(dialogueContent.transform, false);
            }
        }
    }

    void OnMouseEnter()
    {
        //Debug.Log("HI");
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            cursorScript.SpeechCursor();
        }
        //cursorScript.SpeechCursor();
    }

    void OnMouseExit()
    {
        cursorScript.DefaultCursor();
    }
}
