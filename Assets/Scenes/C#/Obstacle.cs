using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstacle : MonoBehaviour
{
    // ���ê���P��L����o�͸I����
    void OnCollisionEnter2D(Collision2D collision)
    {
        // �p�G�I��������O���a�]�ˬd���ҡ^
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); // �R���o�ӻ�ê��
            Debug.Log("��ê���Q���a����úR���I");
        }
    }
}