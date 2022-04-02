using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag=="Glass")
        {
            // Debug.Log("加分");
            GameManager.Instance.score++;
        }

        if (other.transform.tag=="Obstacles")
        {
            // Debug.Log("游戏结束");
            GameManager.Instance.GameOver();
        }
    }
}
