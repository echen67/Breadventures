using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour
{
    [Header("Don't touch")]
    public float currentEnergy = 25f;
    public float maxEnergy = 25f;
    float regenRate = 2f;
    float timer = 0;

    public float percent = 0;

    //Use these to determine max energy
    float level;
    float constant = 0.2f;

    PlayerLevel playerLevel;
    GameObject energyBar;
    RectTransform energyBarTrans;

    void OnEnable()
    {
        playerLevel = gameObject.GetComponent<PlayerLevel>();
        energyBar = GameObject.FindGameObjectWithTag("Energy");
        energyBarTrans = energyBar.GetComponent<RectTransform>();
        level = playerLevel.getLevel();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5f)        //health regenerates every 10 ?
        {
            timer = 0f;
            if (currentEnergy + regenRate >= maxEnergy)
                currentEnergy = maxEnergy;
            else
                currentEnergy += regenRate;
        }
        UpdateDisplay();
    }

    public void levelUpEnergy()
    {
        level = playerLevel.getLevel();
        maxEnergy = Mathf.Pow(level / constant, 2f);
        currentEnergy = maxEnergy;
    }

    public void AddEnergy(float newEnergy)
    {
        currentEnergy += newEnergy;
        if (currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }
    }

    public void UseEnergy(float amount)
    {
        currentEnergy -= amount;
        if (currentEnergy < 0)
        {
            currentEnergy = 0;
        }
    }

    public void EnoughEnergy(float amount)
    {
        if (currentEnergy >= amount)
            currentEnergy -= amount;
    }

    void UpdateDisplay()
    {
        percent = (currentEnergy * 76.6f) / maxEnergy;
        energyBarTrans.sizeDelta = new Vector2(100, percent);
    }
}