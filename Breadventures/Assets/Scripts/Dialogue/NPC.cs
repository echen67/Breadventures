using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPC : MonoBehaviour {

    [Header("Fill this out")]
    public string defaultText;
    public string giverName;
    public string accepted;
    public string declined;

    public GameObject QuestManager;
    QuestManager QuestManagerScript;

    private GameObject GameManager;
    private CursorScript cursorScript;

    void Start()
    {
        //QuestManagerScript = QuestManager.GetComponent<QuestManager>();
        GameManager = GameObject.FindGameObjectWithTag("Scene");
        cursorScript = GameManager.GetComponent<CursorScript>();
    }

    //for the first display block
    public void OnMouseDown()
    {
        //QuestManagerScript.DisplayText(defaultText, giverName);
        //QuestManagerScript.accepted = accepted;
        //QuestManagerScript.declined = declined;
    }

    void OnMouseEnter()
    {
        //Debug.Log("HI");
        cursorScript.SpeechCursor();
    }

    void OnMouseExit()
    {
        cursorScript.DefaultCursor();
    }
}
