using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

    [Header("Enter data here")]
    public string[] sceneNameList;
    public AudioClip[] audioList;
    public Vector2[] transformList;

    [Space]
    public string currentScene = "Menu";

    [Header("Drag refs here")]
    public Slider musicSlider;

    public GameObject player;
    private AudioSource audioSource;
    private float volume = 1;

    PlayerLevel levelScript;
    PlayerHealth healthScript;
    PlayerEnergy energyScript;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioList[0];
        audioSource.Play();
        audioSource.volume = volume;
    }

    void OnLevelWasLoaded()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        audioSource = gameObject.GetComponent<AudioSource>();

        levelScript = gameObject.GetComponent<PlayerLevel>();
        healthScript = gameObject.GetComponent<PlayerHealth>();
        energyScript = gameObject.GetComponent<PlayerEnergy>();
        levelScript.enabled = true;
        healthScript.enabled = true;
        energyScript.enabled = true;
    }

    void Update()
    {
        //audioSource.volume = musicSlider.value;
        //volume = musicSlider.value;
    }

    public void ChangeScene(string sceneName, bool playerExist, int transformID, Vector2 position)
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        ChangeSceneMusic(sceneName);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        if (playerExist)
        {
            //ChangeSceneTransform(transformID);
            ChangeSceneTransform(transformID, position);
        }
        currentScene = sceneName;
        //SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        
    }

    public void ChangeSceneMusic(string sceneName)
    {
        for(int i = 0; i < sceneNameList.Length; i++)
            if (sceneNameList[i] == sceneName)
            {
                audioSource.clip = audioList[i];
                audioSource.Play();
            }
    }

    void ChangeSceneTransform(int transformID, Vector2 position)
    {
        /*for(int i = 0; i < sceneNameList.Length; i++)
        {
            if (sceneName == sceneNameList[i])
                player.transform.position = transformList[i];
        }*/
        //player.transform.position = transformList[transformID];
        player.transform.position = position;
    }
}
