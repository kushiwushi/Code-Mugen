// using System.Collections;
// using UnityEngine;

// public class EnemySpawner : MonoBehaviour
// {
//     public float spawnInterval = 3f;

//     void Start()
//     {
//         StartCoroutine(SpawnEnemies());
//     }


//     IEnumerator SpawnEnemies() {
//         while(true) {
//             yield return new WaitForSeconds(spawnInterval);

//             GameObject enemyObject = EnemyPool.instance.GetPoolObject();
//             Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

//             //randomize axis position
//             int side = Random.Range(0, 4);
//             float spawnOffset = 2f;
//             Vector2 spawnPosition = Vector2.zero;


//             switch (side)
//             {
//                 case 0: // Left
//                     spawnPosition = new Vector2(-screenBounds.x - spawnOffset, Random.Range(-screenBounds.y, screenBounds.y));
//                     break;
//                 case 1: // Right
//                     spawnPosition = new Vector2(screenBounds.x + spawnOffset, Random.Range(-screenBounds.y, screenBounds.y));
//                     break;
//                 case 2: // Top
//                     spawnPosition = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y + spawnOffset);
//                     break;
//                 case 3: // Bottom
//                     spawnPosition = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), -screenBounds.y - spawnOffset);
//                     break;
//             }

//             if (enemyObject != null) {
//                 Enemy enemy = enemyObject.GetComponent<Enemy>();
//                 enemy.ResetEnemy();

//             }

//             enemyObject.transform.position = spawnPosition;
//             enemyObject.SetActive(true);
//         }
//     }
// }
