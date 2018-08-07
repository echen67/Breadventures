using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour {

    [Header("Don't touch")]
    public float level = 1f;
    public float exp = 0f;
    public float maxExp = 26f;
    public float constant = 0.2f;
    float expBarHeight = 76.6f;

    float percent = 0;

    //public GameObject player;
    PlayerHealth playerHealth;
    PlayerEnergy playerEnergy;
    GameObject textBox;
    GameObject expBar;
    RectTransform expBarTrans;

    void OnEnable()
    {
        playerHealth = gameObject.GetComponent<PlayerHealth>();
        playerEnergy = gameObject.GetComponent<PlayerEnergy>();
        textBox = GameObject.FindGameObjectWithTag("Level");
        expBar = GameObject.FindGameObjectWithTag("Exp");
        expBarTrans = expBar.GetComponent<RectTransform>();

        UpdateDisplay();
    }

    /*void Update()
    {
        UpdateDisplay();
    }*/

    public void levelUp(float extraExp)
    {
        level++;
        maxExp = Mathf.Pow(level / constant, 2f);
        exp = extraExp;

        Text levelText = textBox.GetComponent<Text>();
        levelText.text = "Level " + level;

        playerHealth.levelUpHealth();
        playerEnergy.levelUpEnergy();

        UpdateDisplay();
    }

    public void AddExp(float newExp)
    {
        exp += newExp;
        while(exp >= maxExp)
        {
            float extraExp = exp - maxExp;
            levelUp(extraExp);
        }
        UpdateDisplay();
    }

    public float getLevel()
    {
        return level;
    }

    void UpdateDisplay()
    {
        percent = (exp * 76.6f) / maxExp;
        expBarTrans.sizeDelta = new Vector2(100, percent);
    }
}
