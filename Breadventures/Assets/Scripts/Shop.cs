using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    //generic shop script that handles the ui stuff, as well as buying items

    public GameObject[] shopItemsList;      //these gameobjects have the pickup script attached, just so you know
    public bool isShopOpen = false;
    public GameObject shopItemPrefab;

    private Image shopImage;
    private GameObject shopContent;
    private CanvasGroup canvasGroup;

    private GameObject inventory;
    private InventoryPanel inventoryScript;

    private GameObject currency;
    private Currency currencyScript;

    void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory");
        inventoryScript = inventory.GetComponent<InventoryPanel>();

        shopImage = transform.GetChild(0).GetComponent<Image>();
        shopContent = GameObject.FindGameObjectWithTag("ShopContent");
        canvasGroup = GetComponent<CanvasGroup>();

        currency = GameObject.FindGameObjectWithTag("Currency");
        currencyScript = currency.GetComponent<Currency>();
    }

    public void SetUp()
    {
        Debug.Log("Set up");
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        for (int i = 0; i < shopItemsList.Length; i++)
        {
            
            GameObject instance = Instantiate(shopItemPrefab) as GameObject;       //this is the shop item prefab with the shopItem script
            instance.transform.SetParent(shopContent.transform, false);

            instance.GetComponent<ShopItem>().productID = i;           //identify the product by its placement/order in the shop

            instance.transform.GetChild(0).GetComponent<Image>().sprite = shopItemsList[i].GetComponent<SpriteRenderer>().sprite;                    //set the image of this particular product
            instance.transform.GetChild(1).GetComponent<Text>().text = shopItemsList[i].GetComponent<PickUp>().title;                                //set the title
            instance.transform.GetChild(2).GetComponent<Text>().text = shopItemsList[i].GetComponent<PickUp>().buyPrice.ToString() + " breadcrumbs"; //set the price

            Collider2D itemCollider = instance.GetComponent<Collider2D>();
            itemCollider.enabled = true;
        }
    }

	public void BuyItem(int productID)
    {
        GameObject item = shopItemsList[productID];
        PickUp itemScript = item.GetComponent<PickUp>();

        bool aBool = inventoryScript.RoomAvailable();
        bool bBool = currencyScript.currentAmount >= itemScript.buyPrice;
        if (aBool && bBool)
        {
            inventoryScript.AddItem(itemScript.title, itemScript.description, itemScript.health, itemScript.food, itemScript.consumable, itemScript.stackMax, itemScript.image);
            currencyScript.SubtractCurrency(itemScript.buyPrice);
        }
    }
}
