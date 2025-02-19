using System.Collections.Generic;
using UnityEngine;

//needs modification to work with wave manager
public class EnemyPool : MonoBehaviour
{
    public static EnemyPool instance;

    private Dictionary<GameObject, List<GameObject>> enemyPools = new Dictionary<GameObject, List<GameObject>>();
    private int poolSize = 20;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public GameObject GetPoolObject(GameObject enemyPrefab) {
        if (!enemyPools.ContainsKey(enemyPrefab)) {
            enemyPools[enemyPrefab] = new List<GameObject>();

            for (int i = 0; i < poolSize; i++) {
                GameObject obj = Instantiate(enemyPrefab);
                obj.SetActive(false);
                enemyPools[enemyPrefab].Add(obj);
            }
        }

        foreach (GameObject obj in enemyPools[enemyPrefab]) {
            if (!obj.activeInHierarchy) {
                return obj;
            }
        }

        GameObject newObj = Instantiate(enemyPrefab);
        newObj.SetActive(false);
        enemyPools[enemyPrefab].Add(newObj);

        return newObj;
    }
}
