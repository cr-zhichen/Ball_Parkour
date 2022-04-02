using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class Index : MonoBehaviour
{

    public Text HistoricalRecord;

    private void Start()
    {
        string _data = ReadJson();
        var userDatas = JsonConvert.DeserializeObject<List<GameManager.PlayerData>>(_data);

        if (userDatas==null)
        {
            userDatas = new List<GameManager.PlayerData>();
        }
        
        foreach (var _userdata in userDatas)
        {
            
            //将时间转换为分钟和秒
            int minute = (int)_userdata.time / 60;
            int second = (int)_userdata.time % 60;
            
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
            
            HistoricalRecord.text += $"时间：{strMinute + ":" + strSecond} 分数：{_userdata.score} \n";
            HistoricalRecord.text+="===================\n";
        }
    }

    /// <summary>
    /// Json路径
    /// </summary>
    /// <returns>Json位置</returns>
    string JsonPath()
    {
        return Application.streamingAssetsPath + "/DataJson.json";
    }

    //从本地读取json数据
    string ReadJson()
    {
        if (!File.Exists(JsonPath()))
        {
            Debug.Log("读取的文件不存在！");
            return null;
        }

        string json = File.ReadAllText(JsonPath());

        return json;
    }

    public void StatrGame()
    {
        Application.LoadLevel("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
