using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 引入 UI 類別來操作 Text 元素

public class Enemy : MonoBehaviour
{
    public int health = 3; // 設定敵人的生命值
    public int maxHealth = 3; // 最大生命值
    public Text healthText;   // 用來顯示血量的 Text UI 元素

    void Start()
    {
        // 初始化血量顯示
        if (healthText != null)
        {
            healthText.text = "敵人血量: " + health + "/" + maxHealth;
        }
        // 通知 GameManager 有新敵人生成
        GameManager.Instance.RegisterEnemy();
    }
    // 當敵人受到攻擊時，執行這個函式
    public void TakeDamage(int damage)
    {
        health -= damage; // 扣血
        Debug.Log("敵人受傷！剩餘血量：" + health);

        // 更新血量顯示
        if (healthText != null)
        {
            healthText.text = "HP: " + health + "/" + maxHealth; // 顯示血量
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("敵人被消滅！");
        Destroy(gameObject);

        GameManager.Instance.OnEnemyKilled(); // 通知 GameManager
    }
}
