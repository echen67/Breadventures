using UnityEngine;
using System.Collections;

public class QuestManager : MonoBehaviour {

    [Header("Drag references here")]
    public GameObject canvas;
    public TextBox textboxScript;
    public GameObject scrollview;
    public GameObject NextButtonPrefab;
    public GameObject acceptPrefab;
    public GameObject declinePrefab;

    [Header("Ignore these")]
    public string accepted;
    public string declined;

    GameObject acceptButton;
    GameObject declineButton;

    public static int QuestNum;
    int PlayerLevel;

    //Lists containing the titles of all quests
    QuestInstance[] finished = new QuestInstance[QuestNum];
    QuestInstance[] active = new QuestInstance[QuestNum];
    QuestInstance[] current = new QuestInstance[QuestNum];
    QuestInstance[] total = new QuestInstance[QuestNum];

    string[] dialogue = new string[1];
    static string[] nullText = new string[] { "" };
    static QuestInstance nullQuest = new QuestInstance(0, "", "", nullText);

    void Start()
    {
        textboxScript = canvas.GetComponent<TextBox>();

        //Add quests to 'TOTAL' list
        //current[0] = new QuestInstance(1, "Creamfur", "Tutorial", new string[] { "Welcome to ThunderClan!", "Will you accept?" });
        //current[1] = new QuestInstance(2, "Twinklefur", "Explore the Camp!", new string[] { "Go on!" });
        //current[2] = new QuestInstance(2, "Creamfur", "Three", new string[] { "blah" });
    }

    //update due to levelling
    public void UpdateQuestLists()
    {
        for(int i = 0; i < total.Length; i++)
        {
            //if a previously unavailable quest is now available, move it to the current list and remove it from the total list
            if (total[i].level <= PlayerLevel && total[i].level > 0)
            {
                current[i] = total[i];
                total[i] = nullQuest;
            }
        }
    }

    public bool isQuestAvailable(string inputGiver)
    {
        int numAvailQuests = 0;
        for(int i = 0; i < current.Length; i++)
        {
            if(current[i].giver == inputGiver)
            {
                numAvailQuests++;
            }
        }
        if(numAvailQuests == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public string[] CheckForQuests(string inputGiver)
    {
        string[] tempList = new string[5];  //hold title of quest
        for(int i = 0; i < current.Length; i++)
        {
            if (current[i].giver == inputGiver)
            {
                tempList[i] = current[i].title;
            }
        }
        return tempList;
    }

    //Creates the very first dialogue box you see when you click on an NPC (so it contains the default dialogue and any available quests)
    public void DisplayText(string defaultText, string inputGiver)
    {
        int questCounter = 0;
        textboxScript.CreateText(defaultText);
        if(isQuestAvailable(inputGiver) == true)
        {
            string[] availQuests = CheckForQuests(inputGiver);
            for(int i = 0; i < availQuests.Length; i++)
            {
                if(availQuests[i] != null)
                {
                    
                    textboxScript.QuestText(availQuests[i], questCounter);
                    questCounter++;
                }
            }
        }
    }

    //When the player clicks on a quest title
    public void QuestDialogue(string title)
    {
        //iterate through 'current' list to find that quest
        for(int i = 0; i < current.Length; i++)
        {
            if(current[i].title == title)
            {
                textboxScript.DestroyChildren();
                dialogue = current[i].text;
            }
        }
        GameObject nextButton = Instantiate(NextButtonPrefab) as GameObject;
        nextButton.transform.SetParent(scrollview.transform, false);
        
    }

    //start displaying text from the text array
    public void DialogueProgression(int textNum)
    {
        if(textNum < dialogue.Length)
        {
            textboxScript.CreateText(dialogue[textNum]);
            if(textNum == dialogue.Length - 1)
            {
                acceptButton = Instantiate(acceptPrefab) as GameObject;
                acceptButton.transform.SetParent(scrollview.transform, false);
                declineButton = Instantiate(declinePrefab) as GameObject;
                declineButton.transform.SetParent(scrollview.transform, false);
            }
        }
    }

    public void AcceptOrDecline(bool answer)
    {
        if (answer) //if accepted
        {
            textboxScript.CreateText(accepted);
            Destroy(acceptButton);
            Destroy(declineButton);
        }
        else    //if declined
        {
            textboxScript.CreateText(declined);
            Destroy(acceptButton);
            Destroy(declineButton);
        }
    }
}

public struct QuestInstance
{
    public int level;
    public string giver;
    public string title;
    public string[] text;

    public QuestInstance(int level, string giver, string title, string[] text)
    {
        this.level = level;
        this.giver = giver;
        this.title = title;
        this.text = text;
    }
}