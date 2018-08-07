using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public float spawnRate = 5f;
    public int pooledAmount = 5;
    public GameObject[] enemiesList;

    public GameObject enemy;

    void Start()
    {
        enemiesList = new GameObject[pooledAmount];
        for(int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(enemy);
            obj.SetActive(false);
            enemiesList[i] = obj;
        }

        InvokeRepeating("Spawn", spawnRate, spawnRate);

    }

    void Spawn()
    {
        for(int i = 0; i < pooledAmount; i++)
        {
            if (!enemiesList[i].activeInHierarchy)
            {
                enemiesList[i].transform.position = gameObject.transform.position;
                enemiesList[i].SetActive(true);
                return;
            }
        }
    }
}
