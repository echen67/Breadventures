using UnityEngine;
using System.Collections;

public class EndButtonScript : MonoBehaviour {

    public GameObject canvas;
    public TextBox textboxScript;

    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        textboxScript = canvas.GetComponent<TextBox>();
    }

    void OnMouseDown()
    {
        textboxScript.EndChat();
        Destroy(gameObject);
    }
}
