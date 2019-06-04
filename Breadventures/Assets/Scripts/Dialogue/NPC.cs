using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NPC : MonoBehaviour {

    [Header("Fill this out")]
    public string defaultText;
    public string giverName;
    public string accepted;
    public string declined;

    public Quest firstQuest;
    public Quest secondQuest;

    public GameObject QuestManager;
    QuestManager QuestManagerScript;

    private GameObject GameManager;
    private CursorScript cursorScript;
    private CanvasGroup dialoguePanel;

    void Start()
    {
        //QuestManagerScript = QuestManager.GetComponent<QuestManager>();
        GameManager = GameObject.FindGameObjectWithTag("Scene");
        cursorScript = GameManager.GetComponent<CursorScript>();
        dialoguePanel = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<CanvasGroup>();
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
