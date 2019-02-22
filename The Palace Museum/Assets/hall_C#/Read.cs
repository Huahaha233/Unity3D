using UnityEngine;
using UnityEngine.Video;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;//必须引用此变量名，否侧无法获取到第一人称控制器的脚本


public class Read : MonoBehaviour
{
    public GameObject text;//Text_Read
    public GameObject notext;//Text_NoRead
    public GameObject image;
    public GameObject FPS;//第一人称视角用户
    private float x=0;//UI移动的距离,24为起始的x坐标
    private bool isread=false;//判断是否在阅读的状态
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && (text.activeSelf == true))//按下F键进入阅读模式，用户不能移动
        {   
            isread = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && (text.activeSelf == false))
        {
            isread = false;
            notext.SetActive(false);//提示消失
            text.SetActive(true);
            image.SetActive(false);
            FPS.transform.GetComponent<FirstPersonController>().enabled = true;
        }
        if (isread == true)
        {
            notext.SetActive(true);
            text.SetActive(false);
            image.SetActive(true);
            FPS.transform.GetComponent<FirstPersonController>().enabled = false; ;//用户不能移动
            ControlImage();
        }
        

    }
   
    void OnTriggerEnter(Collider other)
    {
        text.SetActive(true);
    }
    void OnTriggerExit(Collider other)
    {
        text.SetActive(false);
    }
    public void ControlImage()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)&&(x<0))
        {
            x += 1024;
            MoveImage();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)&&(x>-2048))//x>1024*（图片数量-1）
        {
            x -= 1024;
            MoveImage();
        }
        
    }
    public void MoveImage()
    {
        image.transform.localPosition = new Vector3(x,160,0);//注意这里一定使用localPosition ，如果使用Position的话，UI的位置会下移，因为Canvas是UI的父类
    }
}
