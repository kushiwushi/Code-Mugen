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

    IEnumerator StartWave()
    {
        while (true) // Change to an infinite loop
        {
            int waveIndexToUse = Mathf.Min(currentWaveIndex, waves.Length - 1); // Get the wave index, capped at the last wave
            WaveData currentWave = waves[waveIndexToUse];
            waveLevel.text = $"Wave {waveIndexToUse + 1}";

            foreach (WaveData.EnemySpawnData enemyData in currentWave.enemies)
            {
                for (int i = 0; i < enemyData.count; i++)
                {
                    SpawnEnemy(enemyData.enemyPrefab);
                    yield return new WaitForSeconds(enemyData.spawnDelay);
                }
            }

            yield return new WaitUntil(() => AreAllEnemiesDefeated());

            waveCountdown = currentWave.waveDelay;
            while (waveCountdown > 0)
            {
                waveTimer.text = $"Next wave in: {waveCountdown:F0}s";
                yield return new WaitForSeconds(1f);
                waveCountdown--;
            }
            waveTimer.text = "";
            waveLevel.text = $"Wave {waveIndexToUse + 1}";
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

            enemyObject.transform.position = GetRandomSpawnPosition(); // Use the random position function
            //enemyObject.transform.position = Vector2.zero;
            enemyObject.SetActive(true);
    }

    private Vector2 GetRandomSpawnPosition()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float offsetX = screenBounds.x * 0.2f; // 20% outside the screen
        float offsetY = screenBounds.y * 0.2f; // 20% outside the screen

        int edge = Random.Range(0, 4);

        Vector2 spawnPosition = Vector2.zero;

        switch (edge)
        {
            case 0: // Left
                spawnPosition = new Vector2(-screenBounds.x - offsetX, Random.Range(-screenBounds.y - offsetY, screenBounds.y + offsetY));
                break;
            case 1: // Right
                spawnPosition = new Vector2(screenBounds.x + offsetX, Random.Range(-screenBounds.y - offsetY, screenBounds.y + offsetY));
                break;
            case 2: // Bottom
                spawnPosition = new Vector2(Random.Range(-screenBounds.x - offsetX, screenBounds.x + offsetX), -screenBounds.y - offsetY);
                break;
            case 3: // Top
                spawnPosition = new Vector2(Random.Range(-screenBounds.x - offsetX, screenBounds.x + offsetX), screenBounds.y + offsetY);
                break;
        }

        return spawnPosition;
    }
}


