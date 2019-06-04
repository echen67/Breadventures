using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour {

    public GameObject inventoryPanel;
    public int inventorySize = 16;
    public Transform[] slots;
    public Collider2D[] colliders;
    private CanvasGroup canvasGroup;
    //private RectTransform rectTransform;
    public bool inventoryVisible;

    void Start () {
        canvasGroup = inventoryPanel.GetComponent<CanvasGroup>();
        slots = new Transform[inventorySize];
        colliders = new Collider2D[inventorySize];
        for(int i = 0; i < inventorySize; i++)
        {
            slots[i] = inventoryPanel.transform.GetChild(i);
            colliders[i] = slots[i].GetComponent<Collider2D>();
        }
        //rectTransform = inventoryPanel.GetComponent<RectTransform>();
        inventoryVisible = false;
        Hide();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryVisible = !inventoryVisible;
            if (inventoryVisible)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }
    }

    void OnMouseDown()
    {
        inventoryVisible = !inventoryVisible;
        if (inventoryVisible)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    public void Clicked()
    {
        inventoryVisible = !inventoryVisible;
        if (inventoryVisible)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    void Hide()
    {
        canvasGroup.alpha = 0f;
        /*for(int i = 0; i < inventorySize; i++)
        {
            colliders[i].enabled = false;
        }*/
        //canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        //rectTransform.sizeDelta = new Vector2(0, 0);
    }

    void Show()
    {
        canvasGroup.alpha = 1f;
        /*for (int i = 0; i < inventorySize; i++)
        {
            colliders[i].enabled = true;
        }*/
        //canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        //rectTransform.sizeDelta = new Vector2(475f, 475f);
    }

}
