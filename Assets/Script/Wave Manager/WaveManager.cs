using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{

    [SerializeField] private WaveData[] waves;
    // [SerializeField] private Transform spawnPoint;
    [SerializeField] private Text waveTimer;
    [SerializeField] private Text waveLevel;
    private int currentWaveIndex = 0;
    private float waveCountdown = 0f;

    void Start()
    {
        StartCoroutine(StartWave());
    }

    IEnumerator StartWave() {
        while (currentWaveIndex < waves.Length)
        {
            WaveData currentWave = waves[currentWaveIndex];
            waveLevel.text = $"Wave {currentWaveIndex + 1}";

            //Array of enemies
            foreach (WaveData.EnemySpawnData enemyData in currentWave.enemies)
            {
                //Enemy count per enemy
                for (int i = 0; i < enemyData.count; i++)
                {
                    //Spawn enemy
                    SpawnEnemy(enemyData.enemyPrefab);
                    yield return new WaitForSeconds(enemyData.spawnDelay);
                }
            }

            //wait till enemies in the current wave is eliminated
            yield return new WaitUntil(() => AreAllEnemiesDefeated());

            waveCountdown = currentWave.waveDelay;
            while (waveCountdown > 0) {
                waveTimer.text = $"Next wave in: {waveCountdown:F0}s";
                yield return new WaitForSeconds(1f);
                waveCountdown--;
            }
            waveTimer.text = "";
            waveLevel.text = $"Wave {currentWaveIndex + 1}";
            currentWaveIndex++;
        }
    }

    private bool AreAllEnemiesDefeated() {
        return GameObject.FindGameObjectsWithTag("Enemy").Length == 0;
    }

    private void SpawnEnemy(GameObject enemyPrefab) {

        GameObject enemyObject = EnemyPool.instance.GetPoolObject(enemyPrefab);
        // Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

            if (enemyObject != null) {
                Enemy enemy = enemyObject.GetComponent<Enemy>();
                enemy.ResetEnemy();
            }

            enemyObject.transform.position = Vector2.zero;
            enemyObject.SetActive(true);
    }
}
