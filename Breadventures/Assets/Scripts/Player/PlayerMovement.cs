using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public static GameObject self;

    public float playerSpeed;
    public float jumpheight;
    public float absVelX = 0f;
    public float absVelY = 0f;
    public bool standing;
    public float standingThreshold;

    public bool currentDirection = false;  //left is false, right is true
    public bool newDirection = false;
    public bool walking = false;
    public bool jumping = false;
    public int doubleJump = 0;     //did you use double jump already (you only get one)
    //public bool crouching = false;

    //private Animator animator;
    private Rigidbody2D body2D;
    private Transform playerTransform;
    private BoxCollider2D collider2d;
    private Vector2 originalSize;
    private Vector2 originalOffset;

    private bool canClimb;

    int enemiesLayer = 8;
    int enemiesMask = 1 << 8;

    AudioSource[] audios;
    AudioSource jumpSFX;

    void Awake()
    {
        if (self == null)
        {
            DontDestroyOnLoad(gameObject);
            self = gameObject;
        }
        else if (self != this)
        {
            Destroy(gameObject);
        }
        body2D = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        //animator = GetComponent<Animator>();
        collider2d = GetComponent<BoxCollider2D>();
        originalSize = collider2d.size;
        originalOffset = collider2d.offset;
        audios = gameObject.GetComponents<AudioSource>();
        jumpSFX = audios[1];
    }

    void Update()
    {
        absVelX = System.Math.Abs(body2D.velocity.x);
        absVelY = System.Math.Abs(body2D.velocity.y);

        standing = absVelY <= standingThreshold;
        if (standing)
        {
            doubleJump = 0;
        }

        Jumping();

        //Change direction based on the last key (left or right) pressed
        if (currentDirection != newDirection)
        {
            transform.Rotate(new Vector3(0, -180, 0));
            currentDirection = newDirection;
        }

        //Moving Left and Right
        //if (Input.GetKey(KeyCode.RightArrow))
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * Time.deltaTime * playerSpeed, Space.World);
            //Vector2 newPos = body2D.position;
            //newPos.x += playerSpeed * Time.deltaTime;
            //body2D.MovePosition(newPos);
            newDirection = true;
            walking = true;
        }

        //if (Input.GetKey(KeyCode.LeftArrow))
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.left * Time.deltaTime * playerSpeed, Space.World);
            newDirection = false;
            walking = true;
        }

        //Idling
        if (absVelY == 0 && !walking)       //&& !crouching
        {
            //animator.SetInteger("Test", 0);
        }

        //Stop walking left and right
        //if (Input.GetKeyUp(KeyCode.LeftArrow))
        if (Input.GetAxis("Horizontal") == 0)
        {
            walking = false;
        }

        //if (Input.GetKeyUp(KeyCode.RightArrow))
        if (Input.GetAxis("Horizontal") == 0)
        {
            walking = false;
        }

        Climbing();
        Glide();
        Stomp();
    } 

    void Glide()
    {
        if (Input.GetKey(KeyCode.V) && body2D.velocity.y < 0)
        {
            body2D.gravityScale = .5f;
        }

        if (Input.GetKeyUp(KeyCode.V))
        {
            body2D.gravityScale = 3f;
        }
    }

    void Stomp()
    {
        bool stomp = false;

        if (Input.GetKey(KeyCode.S) && body2D.velocity.y != 0)      //initiate stomp
        {
            body2D.gravityScale = 15f;
            stomp = true;
        }

        if (Input.GetKeyUp(KeyCode.S) && body2D.velocity.y == 0)       //cancel stomp
        {
            body2D.gravityScale = 3f;
        }

        if (stomp)
        {
            RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), new Vector2(-1, 0), 5, enemiesMask);
            RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), new Vector2(1, 0), 5, enemiesMask);

            if (hitLeft != false)
            {
                hitLeft.rigidbody.AddForce(Vector2.left, ForceMode2D.Impulse);
            }
            if(hitRight != false)
            {
                hitRight.rigidbody.AddForce(Vector2.right, ForceMode2D.Impulse);
            }
            stomp = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            body2D.gravityScale = 0;
            body2D.velocity = new Vector2(0,0);
            canClimb = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            body2D.gravityScale = 3;
            canClimb = false;
        }
    }

    void Climbing()
    {
        //if (Input.GetKey(KeyCode.UpArrow) && canClimb)
        if (Input.GetAxisRaw("Vertical") > 0 && canClimb)
            transform.Translate(Vector2.up * Time.deltaTime * playerSpeed, Space.World);
        //if(Input.GetKey(KeyCode.DownArrow) && canClimb)
        if (Input.GetAxisRaw("Vertical") < 0 && canClimb)
            transform.Translate(Vector2.down * Time.deltaTime * playerSpeed, Space.World);
    }

    void Jumping()
    {
        if (standing == true || doubleJump < 2)
        {
            if (canClimb)
                jumpheight = 0;
            else if (!canClimb)
                jumpheight = 15;
            //if (Input.GetKeyDown(KeyCode.Space))
            if (Input.GetButtonDown("Jump"))
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpheight;
                jumping = true;
                doubleJump++;
                body2D.gravityScale = 3f;
                jumpSFX.Play();
            }
        }
    }
}
