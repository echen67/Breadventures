using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    public static GameObject self;

    private GameObject player;
    public float MinY;
    public float MaxY;
    public float MinX;
    public float MaxX;
	
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
        player = GameObject.FindGameObjectWithTag("Player");
    }

	void LateUpdate () {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -1);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX), Mathf.Clamp(transform.position.y, MinY, MaxY), -1);
	}

    public void setTopRight(Vector2 input)
    {
        MaxX = input.x;
        MaxY = input.y;
    }

    public void setBottomLeft(Vector2 input)
    {
        MinX = input.x;
        MinY = input.y;
    }
}
