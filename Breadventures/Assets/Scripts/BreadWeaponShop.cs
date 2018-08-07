using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BreadWeaponShop : MonoBehaviour {

    //prototype

    public string shopID;

    public GameObject shop;
    public GameObject content;
    public GameObject panelPrefab;
    public GameObject shopImage;
    private Image image;                //

    public GameObject[] shopProducts;   //insert prefabs of items

    private Sprite mySprite;

    public bool isShopOpen = false;

    void Awake()
    {
        shop = GameObject.FindGameObjectWithTag("Shop");
        mySprite = GetComponent<SpriteRenderer>().sprite;
        image = shopImage.GetComponent<Image>();
    }

    void Update()
    {

    }

    void OnMouseDown()
    {
        if(isShopOpen == false)
        {
            //shop.SetActive(true);
            for (int i = 0; i < shopProducts.Length; i++)
            {
                GameObject instance = Instantiate(panelPrefab) as GameObject;       //this is the shop item prefab with the shopItem script
                instance.transform.SetParent(content.transform, false);

                instance.GetComponent<ShopItem>().productID = i;           //identify the product by its placement/order in the shop

                instance.transform.GetChild(0).GetComponent<Image>().sprite = shopProducts[i].GetComponent<SpriteRenderer>().sprite;     //set the image of this particular product
                instance.transform.GetChild(1).GetComponent<Text>().text = shopProducts[i].GetComponent<PickUp>().title;         //set the title
                instance.transform.GetChild(2).GetComponent<Text>().text = shopProducts[i].GetComponent<PickUp>().buyPrice.ToString() + " breadcrumbs"; //set the price

                //ShopItem shopitemScript = instance.GetComponent<ShopItem>();                        //pass information into shop item
            }
            image.sprite = mySprite;
        }
        isShopOpen = true;
    }

    public void BuyItem(int id)
    {

    }

    //REMINDER TO MYSELF WHY THIS SCRIPT NEEDS TO BE BROKEN UP INTO TWO - ONE FOR SELLER AND ONE FOR THE SHOP ITSELF:
    //ShopItem script needs to call above method, 'BuyItem'
    //But to do that, it needs to get a reference to the seller
    //You see the problem, right? (there are multiple sellers)
    //So to fix it, we'll break up this script and make sure to put 'BuyItem' into the SHOP script, not the seller script
    //That way, the 'ShopItem' script can easily find the shop script and therefore the 'BuyItem' method
}
