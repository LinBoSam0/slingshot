using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public Transform slingshotOrigin; // 彈弓的起始點
    public float maxStretch = 2.5f;   // 最大拉伸距離
    public float launchForce = 500f;  // 發射力量

    private Rigidbody2D rb;
    private bool isDragging = false;
    private ElasticRenderer elasticRenderer; // 宣告橡皮筋控制器

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // 讓角色一開始不受重力影響
        {
            rb = GetComponent<Rigidbody2D>();
            elasticRenderer = FindObjectOfType<ElasticRenderer>(); // 找到橡皮筋控制器
        }
    }

    void Update()
    {
        if (isDragging)
        {
            Dragging(); // 進行拖動
        }
    }

    void OnMouseDown()
    {
        isDragging = true; // 當玩家點擊時，開始拖動
    }

    void OnMouseUp()
    {
        isDragging = false; // 玩家放開後，停止拖動
        rb.isKinematic = false; // 讓角色開始受物理影響
        Fire(); // 發射角色
        isDragging = false;
        rb.isKinematic = false;
        Fire();

        if (elasticRenderer != null)
        {
            elasticRenderer.ResetElastic(); // 發射後隱藏橡皮筋
        }
    }

    void Dragging()
    {
        // 取得滑鼠世界座標
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // 確保 Z 軸不變

        // 計算與彈弓中心的距離
        Vector3 direction = mousePosition - slingshotOrigin.position;
        if (direction.magnitude > maxStretch)
        {
            direction = direction.normalized * maxStretch; // 限制最大距離
        }

        // 設定角色位置
        transform.position = slingshotOrigin.position + direction;
    }

    void Fire()
    {
        // 計算發射方向與力量
        Vector3 launchDirection = slingshotOrigin.position - transform.position;
        rb.AddForce(launchDirection * launchForce);
    }
}
