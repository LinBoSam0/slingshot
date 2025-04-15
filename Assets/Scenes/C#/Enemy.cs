using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // �ޤJ UI ���O�Ӿާ@ Text ����

public class Enemy : MonoBehaviour
{
    public int health = 3; // �]�w�ĤH���ͩR��
    public int maxHealth = 3; // �̤j�ͩR��
    public Text healthText;   // �Ψ���ܦ�q�� Text UI ����

    void Start()
    {
        // ��l�Ʀ�q���
        UpdateHealthText();

        // �q�� GameManager ���s�ĤH�ͦ�
        if (GameManager.Instance != null)
        {
            GameManager.Instance.RegisterEnemy();
        }
    }

    // �~���I�s�G���o�ӼĤH�]�w UI Text
    public void SetHealthText(Text text)
    {
        healthText = text;
        UpdateHealthText();
    }

    // ��s��ܥΪ���r
    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "�ĤH��q: " + Mathf.Max(health, 0) + "/" + maxHealth;
        }
    }

    // ��ĤH��������ɡA����o�Ө禡
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0) health = 0;

        Debug.Log("�ĤH���ˡI�Ѿl��q�G" + health);
        UpdateHealthText();

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("�ĤH�Q�����I");
        Destroy(gameObject);

        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnEnemyKilled();
        }
    }
}
