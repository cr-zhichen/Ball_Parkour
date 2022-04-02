using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touch : Button
{

    public string LR;
    
    private void Update()
    {
        if (IsPressed())
        {
            if (LR=="L")
            {
                GameManager.Instance._channelToGenerate.GetComponent<ChannelToGenerate>().L();
            }
            else if (LR=="R")
            {
                GameManager.Instance._channelToGenerate.GetComponent<ChannelToGenerate>().R();
            }
                
        }
    }
}
