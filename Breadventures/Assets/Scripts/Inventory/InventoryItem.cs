using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour {

    public int id;
    public string title;
    public string description;
    public int health;
    public int food;
    public bool consumable;
    public int stackMax;
    public Sprite icon;

    public GameObject inventoryUI;
    public InventoryPanel inventoryPanel;
    
    void Start () {
        inventoryUI = GameObject.FindGameObjectWithTag("Inventory");
        inventoryPanel = inventoryUI.GetComponent<InventoryPanel>();

        icon = Resources.Load<Sprite>(title);
        Image image = GetComponent<Image>();
        image.sprite = icon;
    }

    void OnMouseDown()
    {
        if (Input.GetKey(KeyCode.LeftShift) && consumable)
        {
            Transform argument = transform.parent;
            //bool shouldDestroy = inventoryPanel.UseItem(argument);
            //if (shouldDestroy)
            {
                Destroy(gameObject);
            }
        }
    }

    public void initializeValues(int id, string title, string description, int health, int food, bool consumable, int stackMax)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.health = health;
        this.food = food;
        this.consumable = consumable;
        this.stackMax = stackMax;
    }
}
