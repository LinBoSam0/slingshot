using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int enemyCount = 0;

    public ObstacleSpawner obstacleSpawner; // ��J�ͦ����Ѧ�
    public GameObject enemyPrefab;
    public Text enemyHealthText; // �����W�� UI Text
    public Transform spawnPoint; // ���w�ĤH�X�ͦ�m�]�q Inspector ��i�ӡ^

    public Text levelText; // �Ψ�������d��r�]�Ҧp�u�Ĥ@���v�^

    void Start()
    {
        ShowLevelText("�Ĥ@��"); // ��ܡu�Ĥ@���v
        SpawnEnemy(); // �� �s�W�o�� 
    }

    void Awake()
    {
        Instance = this;
    }

    // ���ͤ@�ӼĤH�ë��w UI Text ���
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
            Debug.LogWarning("Enemy prefab �� spawn point �S���]�w�I");
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
            Debug.Log("�Ҧ��ĤH�w�Q�����A����ͦ���ê���I");
            if (obstacleSpawner != null)
            {
                obstacleSpawner.StopSpawning();
            }
        }
    }

    // ������d��r
    private void ShowLevelText(string level)
    {
        if (levelText != null)
        {
            levelText.text = level;  // ��ܡu�Ĥ@���v
        }
    }
}
