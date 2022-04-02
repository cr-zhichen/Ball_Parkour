using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Channel : MonoBehaviour
{
    public ChannelToGenerate channelToGenerate;
    public Transform endpoint;

    private void Start()
    {
        endpoint=transform.Find("Endpoint");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            channelToGenerate.Generate(endpoint);
            if (channelToGenerate.channelList.Count>2)
            {
                Destroy(channelToGenerate.channelList[0]);
                channelToGenerate.channelList.RemoveAt(0);
            }
        }  
    }
}
