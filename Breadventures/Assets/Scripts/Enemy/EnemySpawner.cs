using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public int range = 5;       // how wide the spawn area is
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
                Vector3 orig = gameObject.transform.position;
                Vector3 pos = new Vector3(orig.x + Random.value * range, orig.y, orig.z);
                enemiesList[i].transform.position = pos;
                enemiesList[i].SetActive(true);
                return;
            }
        }
    }
}
