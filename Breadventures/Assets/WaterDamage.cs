using UnityEngine;
using System.Collections;

public class WaterDamage : MonoBehaviour {

    public int damage;
    private GameObject gameManager;

    private PlayerHealth healthScript;

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("Scene");
        healthScript = gameManager.GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            healthScript.TakeDamage(damage);
        }
    }
}
