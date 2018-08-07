using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    private Animator animator;
    public GameObject player;
    public Vector2 playerTransform;
    public float xPos;

    public bool currentDirection = true;  //left is false, right is true
    public bool newDirection = true;

    public int speed = 10;
    public float range;

    private float movementDelay = 5f;
    public float timer = 0f;
    public float countdown = 2f;

    public int action;      //0 = idle; -1 = left; 1 = right
    public bool sightLine = true;
	
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform.position;
        animator = GetComponent<Animator>();
    }

	void Update () {
        //Timer and decision-making
        timer += Time.deltaTime;
        if(timer >= movementDelay)
        {
            timer = 0;
            float decision = Random.value;

            if (decision <= 0.3)    //move left
            {
                action = -1;
                sightLine = false;
                newDirection = false;
            } else if (decision <= 0.6)     //move right
            {
                action = 1;
                sightLine = true;
                newDirection = true;
            } else if (decision > 0.6)
            {
                action = 0;
            }
        }

        //Change direction based on the last key (left or right) pressed
        if (currentDirection != newDirection)
        {
            transform.Rotate(new Vector3(0, -180, 0));
            currentDirection = newDirection;
        }

        //Movement - left, right, or idle
        if (action == -1)
        {
            //newDirection = false;
            animator.SetInteger("Snake", 1);
            transform.Translate(Vector2.left * Time.deltaTime * speed, Space.World);
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                action = 0;
                countdown = 2f;
            }
        } else if(action == 1)
        {
            //newDirection = true;
            animator.SetInteger("Snake", 1);
            transform.Translate(Vector2.right * Time.deltaTime * speed, Space.World);
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                action = 0;
                countdown = 2f;
            }
        } else if (action == 0)
        {
            animator.SetInteger("Snake", 0);
        }

        //Chase the player down if seen
        if(sightLine == false)
        {
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(-10, 0, 0));
            RaycastHit2D resultLeft = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2(-1, 0), 10);
            if (resultLeft.collider != null && resultLeft.collider.tag == "Player")
            {
                transform.Translate(Vector2.left * Time.deltaTime * speed, Space.World);
            }
        }

        if(sightLine == true)
        {
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(10, 0, 0));
            RaycastHit2D resultRight = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2(1, 0), 10);
            if (resultRight.collider != null && resultRight.collider.tag == "Player")
            {
                transform.Translate(Vector2.right * Time.deltaTime * speed, Space.World);
            }
        }
    }
}
