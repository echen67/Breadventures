using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

    public string title;
    public string description;
    public int health;
    public int food;
    public bool consumable;
    public int stackMax;

    public int buyPrice;
    public int sellPrice;

    public Sprite image;
    public GameObject inventoryPanel;
    private InventoryPanel inventoryScript;
    private SpriteRenderer sprite;
    
    void Awake()
    {
        inventoryPanel = GameObject.FindGameObjectWithTag("Inventory");
        inventoryScript = inventoryPanel.GetComponent<InventoryPanel>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetButton("Collect"))
        {
            bool room = inventoryScript.RoomAvailable();    // check if there's enough room in inventory
            if (room)
            {
                inventoryScript.AddItem(title, description, health, food, consumable, stackMax, image);
                Destroy(gameObject);
            }
        }
    }
}
