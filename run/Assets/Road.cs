using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour {
    public GameObject people;
    private float roadnum = 1;//每段道路的名称
    private float pre_road = 1;//因为房子预制体的名称是固定的，每隔15一个循环
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        InstanceRoad();
	}
    private void InstanceRoad()
    {
        if (people.transform.position.z > roadnum+1)
        {
            GameObject road = Resources.Load("Road"+pre_road,typeof(GameObject)) as GameObject;//强制转换
            Destroy(GameObject.Find("Road"+roadnum));
            roadnum+=2;//这里加2是因为预制体的长度为2

            GameObject instance =Instantiate(road,new Vector3(2,0,roadnum+13),road.transform.rotation);

            float num = roadnum + 14;
            instance.name = "Road"+num;//预制体的命名

            if (pre_road == 15) pre_road = 1;
            else pre_road += 2;
            
        }
    }
}
