using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

    public SceneManagerScript sceneScript;
    public string scene = "Home";

    void Awake()
    {
        sceneScript = GameObject.FindGameObjectWithTag("Scene").GetComponent<SceneManagerScript>();
    }

    void OnMouseDown()
	{
        sceneScript.currentScene = "Home";
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
