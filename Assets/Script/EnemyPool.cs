using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool instance;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private int poolSize = 20;

    [SerializeField]
    private GameObject enemyPrefab;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(enemyPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPoolObject() {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy) {
                return pooledObjects[i];
            }
        }

        GameObject newObj = Instantiate(enemyPrefab);
        newObj.SetActive(false);
        pooledObjects.Add(newObj);

        return newObj;
    }
}
