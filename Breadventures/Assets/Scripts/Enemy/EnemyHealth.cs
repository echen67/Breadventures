using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public float currentHealth;
    public float exp;

    public GameObject[] drops;
    public float[] chances;

    public GameObject damagePrefab;     // drag in inspector

    private GameObject gameManager;
    private PlayerLevel levelScript;
    private GameObject canvas;

    public int range = 2;   // position range that items drop

    AudioSource hurtSFX;

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("Scene");
        levelScript = gameManager.GetComponent<PlayerLevel>();
        hurtSFX = gameObject.GetComponent<AudioSource>();
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    public void TakeDamage(float damage)
    {
        if (hurtSFX != null)
        {
            //Debug.Log("HURT");
            hurtSFX.Play();
        }
        currentHealth -= damage;
        GameObject damageInstance = Instantiate(damagePrefab, transform.position, new Quaternion(), canvas.transform);
        damageInstance.GetComponent<DamageText>().SetText(damage.ToString());
        if (currentHealth <= 0)
        {
            float decision = Random.value;

            for(int i = 0; i < drops.Length; i++)
            {
                if(decision <= chances[i])
                {
                    Vector3 orig = gameObject.transform.position;
                    Vector3 pos = new Vector3(orig.x + Random.value * range, orig.y, orig.z);
                    Instantiate(drops[i], pos, Quaternion.identity);
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
