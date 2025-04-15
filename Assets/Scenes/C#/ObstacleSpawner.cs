using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // 障礙物的預製體
    public float spawnInterval = 2f; // 生成間隔時間
    public float spawnRangeX = 5f; // 障礙物生成範圍的 X 軸
    public float spawnRangeYMin = 0; // 障礙物生成範圍的 Y 軸最小值
    public float spawnRangeYMax = 3f; // 障礙物生成範圍的 Y 軸最大值



    private void Start()
    {
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval); // 設定定時器定期生成障礙物
    }

    // 生成障礙物
    void SpawnObstacle()
    {
        // 隨機選擇 X 和 Y 的位置
        float randomX = Random.Range(0, spawnRangeX);
        float randomY = Random.Range(spawnRangeYMin, spawnRangeYMax);

        // 設定生成位置
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        // 在隨機位置生成障礙物
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
    public void StopSpawning()
    {
        CancelInvoke("SpawnObstacle");
        Debug.Log("已取消障礙物生成");
    }
}
