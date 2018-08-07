using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Currency : MonoBehaviour {

    public int currentAmount;
    private Text currencyText;

    void Awake()
    {
        currencyText = transform.GetChild(0).gameObject.GetComponent<Text>();
        currentAmount = 0;
    }

    public void AddCurrency(int amount)
    {
        currentAmount += amount;
        currencyText.text = currentAmount.ToString();
    }

    public void SubtractCurrency(int amount)
    {
        currentAmount -= amount;
        currencyText.text = currentAmount.ToString();
    }
}
