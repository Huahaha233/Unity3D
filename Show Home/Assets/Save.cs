using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour {
    //存储的思路是：遍历场景中所有的物体；然后将所有的物体转化为json格式保存在MySQL或是本地的数据库中
    // Use this for initialization
    GameObject[] obj;
	void Start ()
    {
        //关键所在将所有类型为gameobject
        //的物体全部保存在gameobject数组中
        obj=FindObjectsOfType(typeof(GameObject)) as GameObject[];

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
