using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 targetPosition; // 回來的目標位置
    public Vector3 teleportPosition = new Vector3(0, 0, 0); // 傳送回來的位置（原點）
    public float returnSpeed = 5f; // 回來的速度
    private bool isReturning = false;

    void Start()
    {
        // 設定初始目標位置，這裡可以自定義
        targetPosition = new Vector3(-3, -2, 0);  // 設定為回到 (0, 0, 0)，即場景原點
    }

    void Update()
    {
        // 檢查投射物的 X 座標是否大於 20
        if (transform.position.x > 20 || transform.position.y < -20)
        {
            // 如果 X 座標大於 20 或 Y 座標小於 -20，將投射物傳送回原點
            transform.position = teleportPosition; // 立即回到原點
        }

        if (isReturning)
        {
            // 如果開始回來，就根據 returnSpeed 控制回來的速度
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, returnSpeed * Time.deltaTime);

            // 當角色到達目標位置時，停止回來
            if (transform.position == targetPosition)
            {
                isReturning = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 假設當角色撞到地面或障礙物時，開始回來
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Ground"))
        {
            // 開始回來
            isReturning = true;
        }
    }
}
