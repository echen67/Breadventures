using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class LoadButton : MonoBehaviour {

    public GameObject sceneManager;
    SaveGame saveScript;

    void Awake()
    {
        saveScript = sceneManager.GetComponent<SaveGame>();
    }

    void OnMouseDown()
    {
        saveScript.Load();
    }
}
