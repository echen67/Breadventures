using UnityEngine;
using System.Collections;

public class PotatoBullet : MonoBehaviour {

    public int damage = 50;
    public int timeOut = 10;
    public int timer = 0;

    void Update()
    {
        timer++;
        if (timer >= timeOut)
        {
            timer = 0;
            gameObject.SetActive(false);
        }
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
