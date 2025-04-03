using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class ElasticRenderer : MonoBehaviour
{
    public LineRenderer leftElastic;  // ������ֵ�
    public LineRenderer rightElastic; // �k����ֵ�
    public Transform slingshotLeft;   // �u�}�����T�w�I
    public Transform slingshotRight;  // �u�}�k���T�w�I
    public Transform projectile;      // ����]�Q�o�g������^

    private void Start()
    {
        // �]�w LineRenderer ��l�ݩ�
        SetupLineRenderer(leftElastic);
        SetupLineRenderer(rightElastic);
    }

    void Update()
    {
        if (projectile != null)
        {
            // �]�w��ֵ����_�I�P���I
            leftElastic.SetPosition(0, slingshotLeft.position);
            leftElastic.SetPosition(1, projectile.position);

            rightElastic.SetPosition(0, slingshotRight.position);
            rightElastic.SetPosition(1, projectile.position);
        }
    }

    void SetupLineRenderer(LineRenderer line)
    {
        line.positionCount = 2; // ��Ӻ��I
        line.startWidth = 0.05f;
        line.endWidth = 0.05f;
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startColor = Color.black;
        line.endColor = Color.black;
    }

    public void ResetElastic()
    {
        // �o�g��A����ֵ��^����
        leftElastic.SetPosition(1, slingshotLeft.position);
        rightElastic.SetPosition(1, slingshotRight.position);
    }
}

