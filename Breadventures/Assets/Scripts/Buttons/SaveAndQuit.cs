using UnityEngine;
using System.Collections;

public class SaveAndQuit : MonoBehaviour {

    SaveGame saveScript;

	void OnEnable()
    {
        saveScript = GameObject.FindGameObjectWithTag("Scene").GetComponent<SaveGame>();
    }

    public void save()
    {
        saveScript.Save();
        Debug.Log("Save");
    }
}
