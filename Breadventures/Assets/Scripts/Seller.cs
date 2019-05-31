using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Seller : MonoBehaviour {

    //Fill this out
    public GameObject[] itemsForSale;       //fill this out with prefabs of 'pickups'

    public GameObject shopItemPrefab;

    //References
    private GameObject shopPanel;
    private Image shopImage;
    //private CanvasGroup canvasGroup;
    private GameObject shopContent;
    private Shop shopScript;

    private Sprite mySprite;

    void Start()
    {
        shopPanel = GameObject.FindGameObjectWithTag("Shop");
        shopImage = shopPanel.transform.GetChild(0).GetComponent<Image>();
        //canvasGroup = shopPanel.GetComponent<CanvasGroup>();
        shopContent = GameObject.FindGameObjectWithTag("ShopContent");
        shopScript = shopPanel.GetComponent<Shop>();

        mySprite = GetComponent<SpriteRenderer>().sprite;
    }

	void OnMouseDown()
    {
        Debug.Log("Clicked seller");
        if(shopScript.isShopOpen == false)
        {
            shopScript.isShopOpen = true;

            //canvasGroup.alpha = 1;
            shopImage.sprite = mySprite;

            for(int i = 0; i < itemsForSale.Length; i++)
            {
                shopScript.shopItemsList = new GameObject[itemsForSale.Length];
                shopScript.shopItemsList[i] = itemsForSale[i];
            }

            shopScript.SetUp();
        }
    }
}
