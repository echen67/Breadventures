using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public int attackDamage;
    public int attackRange;
    public int pushback = 10;

    AudioSource punchSound;

    int enemiesLayer = 8;
    int enemiesMask = 1 << 8;

    private PlayerMovement playerMovement;

    Animator animator;

    void Awake () {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        punchSound = gameObject.GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
	}
	
	void Update () {
        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), new Vector2(-1, 0), attackRange, enemiesMask);
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), new Vector2(1, 0), attackRange, enemiesMask);

        //Debug.DrawRay(gameObject.transform.position, Vector2.right*attackRange, Color.white);
        //Debug.Log(hitLeft.collider.gameObject.tag);

        // Play sound effect and animation regardless of whether there's an enemy
        //if (Input.GetKeyDown(KeyCode.A))
        if (Input.GetButtonDown("Fire1"))
        {
            punchSound.Play();
            animator.SetBool("Attack", true);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("Attack", false);
        }

        if(hitLeft != false && playerMovement.currentDirection == false)
        {
            //if (hitLeft.collider.gameObject.tag == "Enemy" && Input.GetKeyDown(KeyCode.A))
            if (hitLeft.collider.gameObject.tag == "Enemy" && Input.GetButtonDown("Fire1"))
            {
                EnemyHealth enemyHealth = hitLeft.collider.gameObject.GetComponent<EnemyHealth>();

                enemyHealth.TakeDamage(attackDamage);
                Rigidbody2D enemyBody = hitLeft.collider.gameObject.GetComponent<Rigidbody2D>();
                enemyBody.AddForce(new Vector2(-pushback, 0), ForceMode2D.Impulse);
                Debug.Log("LEFT");
            }
        }
        if(hitRight != false && playerMovement.currentDirection == true)
        {
            //if (hitRight.collider.gameObject.tag == "Enemy" && Input.GetKeyDown(KeyCode.A))
            if (hitRight.collider.gameObject.tag == "Enemy" && Input.GetButtonDown("Fire1"))
            {
                EnemyHealth enemyHealth = hitRight.collider.gameObject.GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(attackDamage);
                Rigidbody2D enemyBody = hitRight.collider.gameObject.GetComponent<Rigidbody2D>();
                enemyBody.AddForce(new Vector2(pushback, 0), ForceMode2D.Impulse);
                Debug.Log("RIGHT");
            }
        }
    }
}
