using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChannelToGenerate : MonoBehaviour
{
    public GameObject channelPrefab;
    //旋转速度
    public float rotateSpeed;
    //移动速度
    public float moveSpeed;
    
    public List<GameObject> channelList = new List<GameObject>();

    private void Start()
    {
        Generate(this.transform);
    }

    private void Update()
    {
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        
        if (Input.GetKey(KeyCode.A))
        {
            L();
        }

        if (Input.GetKey(KeyCode.D))
        {
            R();
        }
    }

    public void L()
    {
        transform.Rotate(Vector3.forward, 0.1f*rotateSpeed);
    }

    public void R()
    {
        transform.Rotate(Vector3.back, 0.1f * rotateSpeed);
    }
    
    
    public void Generate(Transform t)
    {
        GameObject g = Instantiate(channelPrefab, t);
        g.transform.parent = this.transform;
        var channel = g.AddComponent<Channel>();

        channelList.Add(g);
        
        channel.channelToGenerate=this;
    }
}

