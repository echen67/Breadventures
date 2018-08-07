using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public int attackDamage;
    public int attackRange;

    int enemiesLayer = 8;
    int enemiesMask = 1 << 8;

    private PlayerMovement playerMovement;

    void Awake () {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
	}
	
	void Update () {
        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), new Vector2(-1, 0), attackRange, enemiesMask);
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), new Vector2(1, 0), attackRange, enemiesMask);

        //Debug.DrawRay(gameObject.transform.position, Vector2.right*attackRange, Color.white);

        //Debug.Log(hitLeft.collider.gameObject.tag);

        if(hitLeft != false && playerMovement.currentDirection == false)
        {
            if (hitLeft.collider.gameObject.tag == "Enemy" && Input.GetKey(KeyCode.A))
            {
                EnemyHealth enemyHealth = hitLeft.collider.gameObject.GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(attackDamage);
                Debug.Log("LEFT");
            }
        }
        if(hitRight != false && playerMovement.currentDirection == true)
        {
            if (hitRight.collider.gameObject.tag == "Enemy" && Input.GetKey(KeyCode.A))
            {
                EnemyHealth enemyHealth = hitRight.collider.gameObject.GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(attackDamage);
                Debug.Log("RIGHT");
            }
        }
    }
}
