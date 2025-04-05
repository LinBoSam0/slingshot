using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int enemyCount = 0;
    public ObstacleSpawner obstacleSpawner; // 拖入生成器參考

    void Awake()
    {
        Instance = this;
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
