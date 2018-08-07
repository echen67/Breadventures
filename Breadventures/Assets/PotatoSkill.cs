using UnityEngine;
using System.Collections;

public class PotatoSkill : MonoBehaviour {

    public int pooledAmount;
    public GameObject[] bullets;

    private PlayerMovement movementScript;

    public GameObject potatoBullet;

    void Awake()
    {
        movementScript = gameObject.GetComponent<PlayerMovement>();
        bullets = new GameObject[pooledAmount];
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(potatoBullet);
            obj.SetActive(false);
            bullets[i] = obj;
        }
    }

    void OnLevelWasLoaded()
    {
        movementScript = gameObject.GetComponent<PlayerMovement>();
        bullets = new GameObject[pooledAmount];
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(potatoBullet);
            obj.SetActive(false);
            bullets[i] = obj;
        }
    }

    void Update()
    {
        FireBullet();
    }

    public void FireBullet()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            for(int i = 0; i < pooledAmount; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    bullets[i].transform.position = gameObject.transform.position;
                    Vector2 dir;
                    if (movementScript.currentDirection)
                    {
                        dir = Vector2.right;
                    }
                    else
                    {
                        dir = Vector2.left;
                    }
                    bullets[i].SetActive(true);
                    bullets[i].GetComponent<Rigidbody2D>().AddForce(dir*15, ForceMode2D.Impulse);
                    return;
                }
            }
        }
    }
}
