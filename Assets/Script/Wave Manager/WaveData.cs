using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "Waves/WaveData")]
public class WaveData : ScriptableObject
{
    [System.Serializable]
    public class EnemySpawnData
    {
        public GameObject enemyPrefab;
        public int count;
        public float spawnDelay;
    }

    public EnemySpawnData[] enemies;
    public float waveDelay;
}
