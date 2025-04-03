using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class ElasticRenderer : MonoBehaviour
{
    public LineRenderer leftElastic;  // 左側橡皮筋
    public LineRenderer rightElastic; // 右側橡皮筋
    public Transform slingshotLeft;   // 彈弓左側固定點
    public Transform slingshotRight;  // 彈弓右側固定點
    public Transform projectile;      // 角色（被發射的物體）

    private void Start()
    {
        // 設定 LineRenderer 初始屬性
        SetupLineRenderer(leftElastic);
        SetupLineRenderer(rightElastic);
    }

    void Update()
    {
        if (projectile != null)
        {
            // 設定橡皮筋的起點與終點
            leftElastic.SetPosition(0, slingshotLeft.position);
            leftElastic.SetPosition(1, projectile.position);

            rightElastic.SetPosition(0, slingshotRight.position);
            rightElastic.SetPosition(1, projectile.position);
        }
    }

    void SetupLineRenderer(LineRenderer line)
    {
        line.positionCount = 2; // 兩個端點
        line.startWidth = 0.05f;
        line.endWidth = 0.05f;
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startColor = Color.black;
        line.endColor = Color.black;
    }

    public void ResetElastic()
    {
        // 發射後，讓橡皮筋回到原位
        leftElastic.SetPosition(1, slingshotLeft.position);
        rightElastic.SetPosition(1, slingshotRight.position);
    }
}

