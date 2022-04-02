/*****************************************

    文件：UI.cs
    日期：#CreateTime#
    功能：Nothing

******************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text Timer;
    public Text score;

    public ChannelToGenerate ChannelToGenerate;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        Timer.text = "00:00";
        score.text = "当前分数：0";

        StartCoroutine(AccordingTo());
        
        ChannelToGenerate = GameManager.Instance._channelToGenerate.GetComponent<ChannelToGenerate>();
    }

    IEnumerator AccordingTo()
    {
        while (true)
        {
            
            //延迟1秒，将GameManager中的时间转换为分钟和秒
            yield return new WaitForSeconds(0.1f);
            GameManager.Instance.timer= GameManager.Instance.timer + 0.1f;
            
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
            Timer.text=strMinute + ":" + strSecond;
            score.text = "当前分数：" + GameManager.Instance.score;

            if (ChannelToGenerate.moveSpeed<=10.0f)
            {
                ChannelToGenerate.moveSpeed += 0.01f;
            }
        }
    }
}
