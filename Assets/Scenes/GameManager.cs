using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int enemyCount = 0;
    public ObstacleSpawner obstacleSpawner; // ��J�ͦ����Ѧ�

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
            Debug.Log("�Ҧ��ĤH�w�Q�����A����ͦ���ê���I");
            if (obstacleSpawner != null)
            {
                obstacleSpawner.StopSpawning();
            }
        }
    }
}
