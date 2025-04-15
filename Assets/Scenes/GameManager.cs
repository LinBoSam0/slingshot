using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int enemyCount = 0;

    public ObstacleSpawner obstacleSpawner; // 拖入生成器參考
    public GameObject enemyPrefab;
    public Text enemyHealthText; // 場景上的 UI Text
    public Transform spawnPoint; // 指定敵人出生位置（從 Inspector 拖進來）

    void Start()
    {
        SpawnEnemy(); // ← 新增這行
    }
    void Awake()
    {
        Instance = this;
    }

    // 產生一個敵人並指定 UI Text 顯示
    public void SpawnEnemy()
    {
        if (enemyPrefab != null && spawnPoint != null)
        {
            GameObject newEnemyObj = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            Enemy enemy = newEnemyObj.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.SetHealthText(enemyHealthText);
            }
        }
        else
        {
            Debug.LogWarning("Enemy prefab 或 spawn point 沒有設定！");
        }
    }

    public void RegisterEnemy()
    {
        enemyCount++;
    }

    public void OnEnemyKilled()
    {
        enemyCount--;

        if (enemyCount <= 0)
        {
            Debug.Log("所有敵人已被消滅，停止生成障礙物！");
            if (obstacleSpawner != null)
            {
                obstacleSpawner.StopSpawning();
            }
        }
    }
}
