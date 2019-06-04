using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public float currentHealth;
    public float maxHealth = 10;
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
        currentHealth = maxHealth;
    }

    private void OnEnable()
    {
        currentHealth = maxHealth;
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
        damageInstance.GetComponent<DamageText>().SetText(damage.ToString(), new Color(163, 0, 255, 255));
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
        Delay();
        levelScript.AddExp(exp);
        gameObject.SetActive(false);
    }

    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(hurtSFX.clip.length);
    }
}
