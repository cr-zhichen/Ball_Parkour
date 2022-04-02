using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItems : MonoBehaviour
{
    
    //随机点物体列表
    public List<GameObject> randomItems;

    public List<GameObject> obstacles;//障碍物列表

    // Start is called before the first frame update
    void Start()
    {
        //获取全部子物体并加入列表
        foreach (Transform child in transform)
        {
            randomItems.Add(child.gameObject);
        }

        foreach (var child in randomItems)
        {
            Instantiate(obstacles[Random.Range(0, obstacles.Count)], child.transform);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
