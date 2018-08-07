using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

    [Header("Fill this out")]
    public string sceneName;    //the scene that you are traveling TO
    public int transformID;     //the position the player should be moved to after traveling through this portal
    public Vector2 transformDirect;     //same as above, but we're doing it in a more direct way this time

    public GameObject sceneManager;
    private SceneManagerScript sceneScript;

    //private bool isFirstUpdate = true;

    void Awake()
    {
        sceneScript = sceneManager.GetComponent<SceneManagerScript>();
    }

    //Yes, this is necessary
    void OnLevelWasLoaded()
    {
        sceneManager = GameObject.FindGameObjectWithTag("Scene");
        sceneScript = sceneManager.GetComponent<SceneManagerScript>();
    }

    /*void Update()
    {
        if (isFirstUpdate)
        {
            isFirstUpdate = false;
            sceneManager = GameObject.FindGameObjectWithTag("Scene");
            sceneScript = sceneManager.GetComponent<SceneManagerScript>();
        }
    }*/

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.X))
        {
            sceneScript.ChangeScene(sceneName, true, transformID, transformDirect);
        }
    }
}
