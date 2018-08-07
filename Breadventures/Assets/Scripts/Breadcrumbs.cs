using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Breadcrumbs : MonoBehaviour {

    public int value;

    private GameObject currency;
    private Currency currencyScript;

    void Awake()
    {
        currencyScript = GameObject.FindGameObjectWithTag("Currency").GetComponent<Currency>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            currencyScript.AddCurrency(value);
            Destroy(gameObject);
        }
    }
}
