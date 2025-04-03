using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstacle : MonoBehaviour
{
    // 當障礙物與其他物體發生碰撞時
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 如果碰撞的物體是玩家（檢查標籤）
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); // 摧毀這個障礙物
            Debug.Log("障礙物被玩家撞到並摧毀！");
        }
    }
}