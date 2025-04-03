using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public Transform slingshotOrigin; // �u�}���_�l�I
    public float maxStretch = 2.5f;   // �̤j�Ԧ��Z��
    public float launchForce = 500f;  // �o�g�O�q

    private Rigidbody2D rb;
    private bool isDragging = false;
    private ElasticRenderer elasticRenderer; // �ŧi��ֵ����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // ������@�}�l�������O�v�T
        {
            rb = GetComponent<Rigidbody2D>();
            elasticRenderer = FindObjectOfType<ElasticRenderer>(); // ����ֵ����
        }
    }

    void Update()
    {
        if (isDragging)
        {
            Dragging(); // �i����
        }
    }

    void OnMouseDown()
    {
        isDragging = true; // ���a�I���ɡA�}�l���
    }

    void OnMouseUp()
    {
        isDragging = false; // ���a��}��A������
        rb.isKinematic = false; // ������}�l�����z�v�T
        Fire(); // �o�g����
        isDragging = false;
        rb.isKinematic = false;
        Fire();

        if (elasticRenderer != null)
        {
            elasticRenderer.ResetElastic(); // �o�g�����þ�ֵ�
        }
    }

    void Dragging()
    {
        // ���o�ƹ��@�ɮy��
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // �T�O Z �b����

        // �p��P�u�}���ߪ��Z��
        Vector3 direction = mousePosition - slingshotOrigin.position;
        if (direction.magnitude > maxStretch)
        {
            direction = direction.normalized * maxStretch; // ����̤j�Z��
        }

        // �]�w�����m
        transform.position = slingshotOrigin.position + direction;
    }

    void Fire()
    {
        // �p��o�g��V�P�O�q
        Vector3 launchDirection = slingshotOrigin.position - transform.position;
        rb.AddForce(launchDirection * launchForce);
    }
}
