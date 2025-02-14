using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnInterval = 3f;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }


    IEnumerator SpawnEnemies() {
        while(true) {
            yield return new WaitForSeconds(spawnInterval);

            GameObject enemyObject = EnemyPool.instance.GetPoolObject();

            Vector2 randomPosition = new Vector2(
                Random.Range(-10f, 10f),
                Random.Range(-6f, 6f)
            );

            if (enemyObject != null) {
                Enemy enemy = enemyObject.GetComponent<Enemy>();
                enemy.ResetEnemy();

            }

            enemyObject.transform.position = randomPosition;
            enemyObject.SetActive(true);
        }
    }
}
