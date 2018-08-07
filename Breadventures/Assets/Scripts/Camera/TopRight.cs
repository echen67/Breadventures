using UnityEngine;
using System.Collections;

public class TopRight : MonoBehaviour {

    private GameObject mainCamera;
    private FollowPlayer followPlayer;

	void Awake() {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        followPlayer = mainCamera.GetComponent<FollowPlayer>();
        followPlayer.setTopRight(new Vector2(transform.position.x, transform.position.y));
	}

    void Update()
    {
        followPlayer.setTopRight(new Vector2(transform.position.x, transform.position.y));
    }
}
