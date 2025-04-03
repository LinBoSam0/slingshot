using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 targetPosition; // �^�Ӫ��ؼЦ�m
    public float returnSpeed = 1f; // �^�Ӫ��t��
    private bool isReturning = false;

    void Start()
    {
        // �]�w�ؼЦ�m�A�o�̥i�H�۩w�q
        targetPosition = new Vector3(-3, -2, 0);  // �]�w���^�� (0, 0, 0)�A�]�N�O�������I
        {
            // �]�w�ؼЦ�m�A�o�̥i�H�۩w�q
            targetPosition = new Vector3(-3, -2, 0);  // �]�w���^�� (0, 0, 0)�A�]�N�O�������I
        }
    }
    void Update()
    {
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
