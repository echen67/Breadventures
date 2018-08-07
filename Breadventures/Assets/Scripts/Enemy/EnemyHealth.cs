using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public float currentHealth;
    public float exp;

    public GameObject[] drops;
    public float[] chances;

    private GameObject gameManager;
    private PlayerLevel levelScript;

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("Scene");
        levelScript = gameManager.GetComponent<PlayerLevel>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            float decision = Random.value;

            for(int i = 0; i < drops.Length; i++)
            {
                if(decision <= chances[i])
                {
                    Instantiate(drops[i], gameObject.transform.position, Quaternion.identity);
                }
            }
            Die();
        }
    }

    void Die()
    {
        levelScript.AddExp(exp);
        gameObject.SetActive(false);
    }
}
