using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    private Collider2D myCollider;
    private bool isActive = true;

    void Awake()
    {
        myCollider = gameObject.GetComponent<Collider2D>();
    }

	void OnMouseDown()
    {
        Debug.Log("Oh no");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("T");
            isActive = !isActive;
            myCollider.enabled = isActive;
        }
    }
}
