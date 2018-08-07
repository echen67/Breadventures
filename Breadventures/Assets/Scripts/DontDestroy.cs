using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

    public static GameObject self;

	void Awake()
    {
        if (self == null)
        {
            DontDestroyOnLoad(gameObject);
            self = gameObject;
        }
        else if (self != this)
        {
            Destroy(this.gameObject);
        }
    }

    /*void OnLevelWasLoaded()
    {
        GameObject other = GameObject.FindGameObjectWithTag("Scene");
        if(other == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(other);
        }
    }*/

}
