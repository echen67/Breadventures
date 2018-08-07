using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Test2 : MonoBehaviour {

    public GameObject tooltip;
    private Text tooltipText;
    private CanvasGroup canvasGroup;

    public string description;

    void Awake()
    {
        tooltipText = tooltip.transform.GetChild(0).GetComponent<Text>();
        canvasGroup = tooltip.GetComponent<CanvasGroup>();

        description = description.Replace("NEWLINE", "\n");
    }

    void OnMouseOver()
    {
        canvasGroup.alpha = 1;
        tooltipText.text = description;
        tooltip.transform.position = gameObject.transform.position;
    }

    void OnMouseExit()
    {
        canvasGroup.alpha = 0;
    }
}
