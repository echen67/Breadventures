using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [Header("Don't touch")]
    public float currentHealth = 25f;
    public float maxHealth = 25f;
    float regenRate = 5f;
    float timer = 0;

    public float percent = 0;
    public float timeInvincible = 2f;

    public GameObject damagePrefab;     // Drag prefab in inspector

    bool isInvincible = false;
    float invincibleTimer = 0;

    //Use these to determine max health
    float level;
    float constant = 0.2f;

    PlayerEnergy playerEnergy;
    PlayerLevel playerLevel;
    GameObject healthBar;
    GameObject player;
    RectTransform healthBarTrans;
    SpriteRenderer sprite;
    GameObject canvas;

    void OnEnable() {
        playerLevel = gameObject.GetComponent<PlayerLevel>();
        playerEnergy = gameObject.GetComponent<PlayerEnergy>();
        healthBar = GameObject.FindGameObjectWithTag("Health");
        healthBarTrans = healthBar.GetComponent<RectTransform>();
        level = playerLevel.getLevel();
        player = GameObject.FindGameObjectWithTag("Player");
        sprite = player.GetComponent<SpriteRenderer>();
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    /*void OnLevelWasLoaded()
    {
        healthBar = GameObject.FindGameObjectWithTag("Health");
        healthBarTrans = healthBar.GetComponent<RectTransform>();
    }*/
	
	void Update () {
        timer += Time.deltaTime;
        if(timer >= 10f)        //health regenerates every 10 ?
        {
            timer = 0f;
            if (currentHealth + regenRate >= maxHealth)
                currentHealth = maxHealth;
            else
                currentHealth += regenRate;
        }
        UpdateDisplay();    // update health bar ui

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
                sprite.color = Color.white;
            }
        }
	}

    public void levelUpHealth()
    {
        level = playerLevel.getLevel();
        maxHealth = Mathf.Pow(level / constant, 2f);
        currentHealth = maxHealth;
    }

    public void AddHealth(float newHealth)
    {
        currentHealth += newHealth;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        // don't take damage if currently invincible
        if (isInvincible)
        {
            return;
        }
        //Debug.Log("TAKE DAMAGE");
        currentHealth -= damage;
        isInvincible = true;
        invincibleTimer = timeInvincible;   // 0 --> 2
        sprite.color = new Color(1f, 0.8f, 0.8f);
        GameObject damageInstance = Instantiate(damagePrefab, player.transform.position, new Quaternion(0, 0, 0, 0), canvas.transform);
        damageInstance.GetComponent<DamageText>().SetText(damage.ToString());
        if (currentHealth <= 0)
        {
            Debug.Log("You died");
            currentHealth = maxHealth * .1f;
            playerEnergy.currentEnergy = 0;
            playerLevel.exp = 0;
            //change scene to closest town BEHIND
        }
    }

    void UpdateDisplay()
    {
        percent = (currentHealth * 76.6f) / maxHealth;
        healthBarTrans.sizeDelta = new Vector2(100, percent);
    }
}