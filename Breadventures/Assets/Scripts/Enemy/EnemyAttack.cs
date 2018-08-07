using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public float attackDelay;
    public float attackDamage;
    public bool canAttackPlayer;
    public float timer;
    public float pushBack;

    private GameObject gameManager;
    private GameObject player;
    private PlayerHealth playerHealth;
    private Rigidbody2D playerBody;
    private Transform playerTransform;

	void Awake () {
        canAttackPlayer = false;
        timer = 0f;
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("Scene");
        playerHealth = gameManager.GetComponent<PlayerHealth>();
        playerBody = player.GetComponent<Rigidbody2D>();
        playerTransform = player.GetComponent<Transform>();
	}
	
	void Update () {
        timer += Time.deltaTime;
        if (timer >= attackDelay && canAttackPlayer)
        {
            timer = 0f;
            playerHealth.TakeDamage(attackDamage);
            if(transform.position.x > playerTransform.position.x)
            {
                playerBody.AddForce(new Vector2(-pushBack,0), ForceMode2D.Impulse);
            } else if(transform.position.x < playerTransform.position.x)
            {
                playerBody.AddForce(new Vector2(pushBack, 0), ForceMode2D.Impulse);
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            canAttackPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            canAttackPlayer = false;
        }
    }
}
