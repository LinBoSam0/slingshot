using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // ��ê�����w�s��
    public float spawnInterval = 2f; // �ͦ����j�ɶ�
    public float spawnRangeX = 5f; // ��ê���ͦ��d�� X �b
    public float spawnRangeYMin = 0; // ��ê���ͦ��d�� Y �b�̤p��
    public float spawnRangeYMax = 3f; // ��ê���ͦ��d�� Y �b�̤j��



    private void Start()
    {
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval); // �]�w�w�ɾ��w���ͦ���ê��
    }

    // �ͦ���ê��
    void SpawnObstacle()
    {
        // �H����� X �M Y ����m
        float randomX = Random.Range(0, spawnRangeX);
        float randomY = Random.Range(spawnRangeYMin, spawnRangeYMax);

        // �]�w�ͦ���m
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        // �b�H����m�ͦ���ê��
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
    public void StopSpawning()
    {
        CancelInvoke("SpawnObstacle");
        Debug.Log("�w������ê���ͦ�");
    }
}
