using UnityEngine;
using System.Collections;

public class BottomLeft : MonoBehaviour
{
    private GameObject mainCamera;
    private FollowPlayer followPlayer;

    void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        followPlayer = mainCamera.GetComponent<FollowPlayer>();
        followPlayer.setBottomLeft(new Vector2(transform.position.x, transform.position.y));
    }

    void Update()
    {
        followPlayer.setBottomLeft(new Vector2(transform.position.x, transform.position.y));
    }
}