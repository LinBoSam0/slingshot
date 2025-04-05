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
        if (healthText != null)
        {
            healthText.text = "�ĤH��q: " + health + "/" + maxHealth;
        }
        // �q�� GameManager ���s�ĤH�ͦ�
        GameManager.Instance.RegisterEnemy();
    }
    // ��ĤH��������ɡA����o�Ө禡
    public void TakeDamage(int damage)
    {
        health -= damage; // ����
        Debug.Log("�ĤH���ˡI�Ѿl��q�G" + health);

        // ��s��q���
        if (healthText != null)
        {
            healthText.text = "HP: " + health + "/" + maxHealth; // ��ܦ�q
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("�ĤH�Q�����I");
        Destroy(gameObject);

        GameManager.Instance.OnEnemyKilled(); // �q�� GameManager
    }
}
