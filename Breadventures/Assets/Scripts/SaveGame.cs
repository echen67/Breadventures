using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour {

    //Data
    public float health;
    public float energy;
    public float exp;
    public float level;
    public string currentScene = "Home";
    //public Vector2 playerPos;

    //References
    PlayerHealth healthScript;
    PlayerEnergy energyScript;
    PlayerLevel levelScript;
    SceneManagerScript sceneScript;
    Transform playerTrans;

    /*void Awake()
    {
        healthScript = gameObject.GetComponent<PlayerHealth>();
        energyScript = gameObject.GetComponent<PlayerEnergy>();
        levelScript = gameObject.GetComponent<PlayerLevel>();
        sceneScript = gameObject.GetComponent<SceneManagerScript>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }*/

    public void UpdateData()
    {
        healthScript = gameObject.GetComponent<PlayerHealth>();
        energyScript = gameObject.GetComponent<PlayerEnergy>();
        levelScript = gameObject.GetComponent<PlayerLevel>();
        sceneScript = gameObject.GetComponent<SceneManagerScript>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        health = healthScript.currentHealth;
        energy = energyScript.currentEnergy;
        exp = levelScript.exp;
        level = levelScript.level;
        currentScene = sceneScript.currentScene;
        //playerPos = playerTrans.transform.position;
    }

    public void RestoreData()
    {
        SceneManager.LoadScene(currentScene, LoadSceneMode.Single);
    }

	public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        UpdateData();

        PlayerData data = new PlayerData(health, energy, exp, level, currentScene);
        bf.Serialize(file, data);
        file.Close();

        Debug.Log("Saved");
        //SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        //Application.Quit();
    }

    public void Load()
    {
        Debug.Log(Application.persistentDataPath);
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);

            currentScene = data.currentScene;
            //health = data.health;
            //energy = data.energy;
            //exp = data.exp;


            file.Close();

            SceneManager.LoadScene(currentScene, LoadSceneMode.Single);
            healthScript = gameObject.GetComponent<PlayerHealth>();
            energyScript = gameObject.GetComponent<PlayerEnergy>();
            levelScript = gameObject.GetComponent<PlayerLevel>();
            healthScript.currentHealth = data.health;
            energyScript.currentEnergy = data.energy;
            levelScript.exp = data.exp;
            levelScript.level = data.level;
        }
        Debug.Log("Loading");
    }
}

[Serializable]
public class PlayerData
{
    public float health;
    public float energy;
    public float exp;
    public float level;
    public string currentScene;
    //public Vector2 playerPos;

    public PlayerData(float health, float energy, float exp, float level, string currentScene)
    {
        this.health = health;
        this.energy = energy;
        this.exp = exp;
        this.level = level;
        this.currentScene = currentScene;
        //this.playerPos = playerPos;
    }
}