using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBox : MonoBehaviour {

    [Header("Drag refs here")]
    public Text text;
    //public Text prefab;
    public GameObject scrollview;
    public GameObject endButtonPrefab;
    public GameObject content;
    Transform contentTrans;
    public Text questTitlePrefab;

    bool isTalking = false;
    //bool isFirstDialogue = false;

    void Start()
    {
        scrollview.SetActive(false);
        contentTrans = content.transform;
    }

    public void CreateText(string input)
    {
        
        scrollview.SetActive(true);
        if (isTalking == false)     //!isTalking
        {
            GameObject endButton = Instantiate(endButtonPrefab) as GameObject;
            endButton.transform.SetParent(scrollview.transform, false);
        }
        isTalking = true;

        text.text = input;
        //Text test = Instantiate(prefab) as Text; 
        //test.transform.SetParent(gameObject.transform, false);
        //Text test = gameObject.AddComponent<Text>();
        //test.text = "testtext";
        //GameObject test = Instantiate(new GameObject());
        //test.transform.SetParent(gameObject.transform, false);
        //Text testtext = test.AddComponent<Text>();
        //testtext.text = "testtext";
        //testtext.font = Resources.GetBuiltinResource<Font>("Arial.ttf") as Font;
    }

    //creates clickable text
    public void QuestText(string inputTitle, int questCounter)
    {
        int subtractThis = questCounter * 30;   //handle the spacing between quest titles
        Text questTitle = Instantiate(questTitlePrefab) as Text;
        questTitle.transform.SetParent(content.transform, false);
        questTitle.rectTransform.anchoredPosition = new Vector2(0, 80-subtractThis);

        Button buttonScript = questTitle.GetComponent<Button>();
        buttonScript.questTitle = inputTitle;
    }

    public void EndChat()
    {
        scrollview.SetActive(false);
        text.text = "";
        isTalking = false;
        DestroyChildren();
    }

    public void DestroyChildren()
    {
        foreach (Transform t in contentTrans)
        {
            Destroy(t.gameObject);
        }
    }
}
