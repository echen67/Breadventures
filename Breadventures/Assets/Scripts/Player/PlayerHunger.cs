using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHunger : MonoBehaviour {

    public float currentHunger;
    public float maxHunger;

    public float degenRate;
    public float timer;

    PlayerLevel playerLevel;
    PlayerHealth playerHealth;
    public float level;
    public float constant = 0.2f;

    public GameObject player;
    public Slider hungerBar;

    void Awake () {
        currentHunger = 25f;
        hungerBar.value = currentHunger;
        maxHunger = 25f;
        hungerBar.maxValue = maxHunger;

        degenRate = .5f;
        timer = 0f;

        playerHealth = player.GetComponent<PlayerHealth>();
        playerLevel = player.GetComponent<PlayerLevel>();
        level = playerLevel.getLevel();
    }

	void Update () {
        hungerBar.value = currentHunger;
        timer += Time.deltaTime;
        /*if (timer >= 10f)
        {
            timer = 0f;
            currentHunger -= degenRate;
        }*/
        currentHunger -= degenRate * Time.deltaTime;
        if (currentHunger <= 0)
        {
            playerHealth.currentHealth -= .1f;
        }
    }

    public void levelUpHunger()
    {
        level = playerLevel.getLevel();
        maxHunger = Mathf.Pow(level / constant, 2f);
        hungerBar.maxValue = maxHunger;
        currentHunger = maxHunger;
        hungerBar.value = currentHunger;
    }

    public void AddHunger(float newHunger)
    {
        currentHunger += newHunger;
        if (currentHunger > maxHunger)
        {
            currentHunger = maxHunger;
        }
    }
}
