using UnityEngine;
using System.Collections;

public class SlotScript : MonoBehaviour {

    //Info
    public string title;
    public string description;
    public int health;
    public int food;
    public bool consumable;
    public int stackMax;

    //Refs
    public GameObject inventoryPanel;
    private InventoryPanel inventoryScript;

    void Awake()
    {
        inventoryPanel = transform.parent.gameObject;
        inventoryScript = inventoryPanel.GetComponent<InventoryPanel>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(1))
        {
            //if the item is consumable, pass its health and food info back to inventory panel
            if (consumable)
            {
                inventoryScript.UseItem(title, health, food);
            }
        }
    }

    public void SlotInfo(string title, string description, int health, int food, bool consumable, int stackMax)
    {
        this.title = title;
        this.description = description;
        this.health = health;
        this.food = food;
        this.consumable = consumable;
        this.stackMax = stackMax;
    }
}
