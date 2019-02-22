using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*此碰撞脚本是控制物体进入建筑物的脚本*/
public class Collsion : MonoBehaviour {
    public GameObject text;
    public static bool isregiste = false;//用于判断用户是否为已注册用户，如果为false则不是，如果为true则为注册用，在外部给它赋值
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.F)&&(text.activeSelf== true))//注册用户与游客都能进入
        {
            if ((isregiste == true)&& text.name == "Text_registe")//后面的条件是为了不让用户无论在前殿还是后殿都只能进入后殿
            {
                SceneManager.LoadScene("hall_registe");
            }
            else if(text.name=="Text")//这里加一条判断语句是因为，若是不加的话，游客就会从后殿的位置进入宫殿
            {
                SceneManager.LoadScene("hall");
            }
            
        }
      
    }
    void OnTriggerEnter(Collider other)
    {
        text.SetActive(true);
        //text.transform.Find("Text").gameObject.SetActive(true);
        //按下F键转换场景，进入宫殿场景
        
    }
    void OnTriggerExit(Collider other)
    {
        text.SetActive(false);
    }

   
}
