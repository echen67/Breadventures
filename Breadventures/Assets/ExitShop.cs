using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExitShop : MonoBehaviour {

    private GameObject shopPanel;
    private CanvasGroup canvasGroup;
    private GameObject content;
    private Shop shopScript;

    void Awake()
    {
        shopPanel = GameObject.FindGameObjectWithTag("Shop");
        content = GameObject.FindGameObjectWithTag("ShopContent");
        canvasGroup = shopPanel.GetComponent<CanvasGroup>();
        shopScript = shopPanel.GetComponent<Shop>();
    }

    void OnMouseDown()
    {
        canvasGroup.alpha = 0;
        shopScript.isShopOpen = false;
        //Destroy all the items in the shop
        int numChildren = content.transform.childCount;
        for(int i = 0; i < numChildren; i++)
        {
            GameObject singleChild = content.transform.GetChild(i).gameObject;
            Destroy(singleChild);
        }
    }
}
