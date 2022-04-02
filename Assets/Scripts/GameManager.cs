using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //单例模式
    public static GameManager Instance { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public GameObject channelToGenerate;
    public GameObject player;
    
    public GameObject _channelToGenerate;
    public GameObject _player;

    //计时器
    public float timer = 0;
    //分数保存
    public int score = 0;

    public GameObject OverUI;

    public GameObject UI;


    private void Start()
    {
        timer=0;
        score=0;
        _channelToGenerate=Instantiate(channelToGenerate);
        _player=Instantiate(player);
        UI.SetActive(true);
    }
    public void GameOver()
    {
        OverUI.SetActive(true);
        UI.SetActive(false);
        Destroy(_channelToGenerate);
        Destroy(_player);

        string _data = ReadJson();
        
        var userDatas = JsonConvert.DeserializeObject<List<PlayerData>>(_data);

        if (userDatas==null)
        {
            userDatas = new List<PlayerData>();
        }
        
        if(userDatas.Count>=10)
        {
            userDatas.RemoveAt(0);
        }
        
        userDatas.Add(new PlayerData()
        {
            score = score,
            time = timer
        });
        
        SaveJson(userDatas);
        
    }

    public void Restart()
    {
        timer=0;
        score=0;
        _channelToGenerate=Instantiate(channelToGenerate);
        _player=Instantiate(player);
        OverUI.SetActive(false);
        UI.SetActive(true);
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
    
    //保存json数据到本地
    void SaveJson(List<PlayerData> jsonData)
    {
        //如果本地没有对应的json 文件，重新创建
        if (!File.Exists(JsonPath()))
        {
            // Debug.Log("新建文件");
            File.Create(JsonPath());
        }

        var json = JsonConvert.SerializeObject(jsonData);
        File.WriteAllText(JsonPath(), json);
        // Debug.Log("保存成功");
    }
    
    /// <summary>
    /// 玩家数据
    /// </summary>
    [Serializable]
    public class PlayerData
    {
        public float time;
        public int score;
    }

}
