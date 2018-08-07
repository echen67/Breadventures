using UnityEngine;
using System.Collections;

public class HandleShop : MonoBehaviour {

    public GameObject shopPanel;

    void Awake()
    {
        //shopPanel = GameObject.FindGameObjectWithTag("Shop");
        GameObject shopInstance = Instantiate(shopPanel);
        shopInstance.SetActive(true);
        shopInstance.transform.SetParent(gameObject.transform, false);
    }

    void OnDestroy()
    {
        //shopPanel.SetActive(true);
    }
}
