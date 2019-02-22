using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;//必须引用此变量名，否侧无法获取到第一人称控制器的脚本

public class outgame : MonoBehaviour {
    private bool ismune = false;//是否弹出菜单状态
    public GameObject outgametext;//退出游戏的按钮
    public GameObject FPS;//用户
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)&&ismune==false)
        {
            ismune = true;
            Mune();
           
        }
        else if (Input.GetKeyDown(KeyCode.Escape)&& ismune == true)
        {
            ismune = false;
            Mune();
            
        }
    }
    public void Mune()//处理菜单
    {
        if (ismune == true)
        {
            
            FPS.transform.GetComponent<FirstPersonController>().enabled = false;
            outgametext.SetActive(true);//激活退出游戏的按钮
        }
        else
        {
            
            FPS.transform.GetComponent<FirstPersonController>().enabled = true;
            outgametext.SetActive(false);//取消退出游戏的按钮
        }
    }
    public void Click()
    {
        SceneManager.LoadScene("change");
    }
}
