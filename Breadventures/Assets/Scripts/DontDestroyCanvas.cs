using UnityEngine;
using System.Collections;

public class DontDestroyCanvas : MonoBehaviour {

    public static GameObject canvasStatic;

    void Awake()
    {
        if (canvasStatic == null)
        {
            DontDestroyOnLoad(gameObject);
            canvasStatic = gameObject;
        }
        else if (canvasStatic != this)
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {

    }
}
