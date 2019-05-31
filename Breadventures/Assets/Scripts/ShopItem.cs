using UnityEngine;
using System.Collections;

public class ShopItem : MonoBehaviour {

    public int productID;

    private GameObject shopPanel;
    private Shop shopScript;

    /*void OnEnable()
    {
        shopPanel = GameObject.FindGameObjectWithTag("Shop");
        shopScript = shopPanel.GetComponent<Shop>();
    }*/

	void OnMouseDown()
    {
        shopPanel = GameObject.FindGameObjectWithTag("Shop");
        shopScript = shopPanel.GetComponent<Shop>();

        shopScript.BuyItem(productID);
    }
}
