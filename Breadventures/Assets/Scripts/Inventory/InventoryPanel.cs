using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour {

    public static int inventorySize = 16;   //total size of inventory
    public GameObject gameManager;
    PlayerHealth playerHealth;
    PlayerEnergy playerEnergy;

    public Sprite blankSlot;

    public int inventoryFull = 0;                                  //how much you're currently holding?

    public Text[] textList = new Text[inventorySize];              //the text that displays the number of each item
    public string[] items = new string[inventorySize];             //dif version of Item2[] list above
    public GameObject[] slots = new GameObject[inventorySize];     //dif version of slotsList below
    public SlotScript[] scripts = new SlotScript[inventorySize];   //get all slot scripts
    public int[] amountsList = new int[inventorySize];             //keeps track of how many of each item you have in each slot
    
    void Awake () {
        //initialize playerHealth and playerHunger
        gameManager = GameObject.FindGameObjectWithTag("Scene");
        playerHealth = gameManager.GetComponent<PlayerHealth>();
        playerEnergy = gameManager.GetComponent<PlayerEnergy>();

        //get all transforms of children (aka slots) of the inventory panel? also get the text components two birbs with one stone yay
        for(int i = 0; i < transform.childCount; i++)
        {
            slots[i] = transform.GetChild(i).gameObject;
            scripts[i] = slots[i].GetComponent<SlotScript>();
            //slotsList[i] = transform.GetChild(i);
            textList[i] = slots[i].transform.GetChild(0).GetComponent<Text>();
        }
    }

    //THIS function determines whether pickup should destroy itself or not - it should if there is room available
    public bool RoomAvailable()
    {
        bool answer = (inventoryFull < inventorySize) ? true : false;
        return answer;
    }
    
    //pass in title for identification and stackMax
    public void AddItem(string title, string description, int health, int food, bool consumable, int stackMax, Sprite sprite)
    {
        //adding onto a stackable slot
        for(int i = 0; i < inventorySize; i++)
        {
            if(items[i] == title && amountsList[i] < stackMax)
            {
                amountsList[i]++;
                textList[i].text = amountsList[i].ToString();
                return;
            }
        }

        //starting a new slot
        for(int i = 0; i < inventorySize; i++)      //loop through inventory to find empty slot
        {
            if(amountsList[i] == 0)
            {
                items[i] = title;
                amountsList[i] = 1;
                textList[i].text = amountsList[i].ToString();
                slots[i].GetComponent<Image>().sprite = sprite;
                scripts[i].SlotInfo(title, description, health, food, consumable, stackMax);
                return;
            }
        }
    }

    public void UseItem(string title, int health, int food)
    {
        for(int i = 0; i < inventorySize; i++)      //loop through inventory
        {
            if(items[i] == title)                   //find the matching stack  BUG:
            {
                amountsList[i]--;
                textList[i].text = amountsList[i].ToString();
                playerHealth.AddHealth(health);
                playerEnergy.AddEnergy(food);
                if(amountsList[i] == 0)             //if that slot is now empty
                {
                    textList[i].text = "";
                    items[i] = "";
                    slots[i].GetComponent<Image>().sprite = blankSlot;
                }
            }
        }
    }
}