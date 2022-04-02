using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public Text score;
    public Text time;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        //将时间转换为分钟和秒
        int minute = (int)GameManager.Instance.timer / 60;
        int second = (int)GameManager.Instance.timer % 60;
        //将分钟和秒转换为字符串
        string strMinute = minute.ToString();
        string strSecond = second.ToString();
        //如果分钟小于10，则在前面补0
        if (minute < 10)
        {
            strMinute = "0" + strMinute;
        }
        //如果秒小于10，则在前面补0
        if (second < 10)
        {
            strSecond = "0" + strSecond;
        }
        time.text="游戏时间："+strMinute + ":" + strSecond;
        score.text = "当前分数：" + GameManager.Instance.score;
    }

    public void Restart()
    {
        //重新开始游戏
        GameManager.Instance.Restart();
    }

    public void ReturnToInterface()
    {
        Application.LoadLevel("index");
    }

}
