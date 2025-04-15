using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 targetPosition; // �^�Ӫ��ؼЦ�m
    public Vector3 teleportPosition = new Vector3(0, 0, 0); // �ǰe�^�Ӫ���m�]���I�^
    public float returnSpeed = 5f; // �^�Ӫ��t��
    private bool isReturning = false;

    void Start()
    {
        // �]�w��l�ؼЦ�m�A�o�̥i�H�۩w�q
        targetPosition = new Vector3(-3, -2, 0);  // �]�w���^�� (0, 0, 0)�A�Y�������I
    }

    void Update()
    {
        // �ˬd��g���� X �y�ЬO�_�j�� 20
        if (transform.position.x > 20 || transform.position.y < -20)
        {
            // �p�G X �y�Фj�� 20 �� Y �y�Фp�� -20�A�N��g���ǰe�^���I
            transform.position = teleportPosition; // �ߧY�^����I
        }

        if (isReturning)
        {
            // �p�G�}�l�^�ӡA�N�ھ� returnSpeed ����^�Ӫ��t��
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, returnSpeed * Time.deltaTime);

            // �����F�ؼЦ�m�ɡA����^��
            if (transform.position == targetPosition)
            {
                isReturning = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ���]���⼲��a���λ�ê���ɡA�}�l�^��
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Ground"))
        {
            // �}�l�^��
            isReturning = true;
        }
    }
}
