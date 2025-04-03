using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 targetPosition; // 回來的目標位置
    public float returnSpeed = 1f; // 回來的速度
    private bool isReturning = false;

    void Start()
    {
        // 設定目標位置，這裡可以自定義
        targetPosition = new Vector3(-3, -2, 0);  // 設定為回到 (0, 0, 0)，也就是場景原點
        {
            // 設定目標位置，這裡可以自定義
            targetPosition = new Vector3(-3, -2, 0);  // 設定為回到 (0, 0, 0)，也就是場景原點
        }
    }
    void Update()
    {
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
