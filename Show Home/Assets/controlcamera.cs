using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlcamera : MonoBehaviour {

    private float distance = 0;
    
    private  bool isrotate = false;
    private bool ismove = false;
    private float rotate_x=0;
    private float rotate_y = 0;
    public Camera camera;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        ScrollWheel();
        RotateCamera();
        Movecamera();
        
	}

    //获取鼠标中键滚轮的方向
    void ScrollWheel()
    {
        distance = Input.GetAxis("Mouse ScrollWheel")*5;
        
        camera.transform.position += transform.TransformDirection(new Vector3(0,0,distance));//向摄像机面向的方向前进，等于transform.forward
    }
    void RotateCamera()
    {
        
        //判断是否按下鼠标右键
        if (Input.GetMouseButtonDown(1)) isrotate = true;
        
        if (Input.GetMouseButtonUp(1)) isrotate = false;

      //Input.GetAxis("Mouse X");//得到鼠标在水平方向的滑动,向左时返回负数，向右返回正数
        //Input.GetAxis("Mouse Y");//得到鼠标在垂直方向的滑动,向下时返回负数，向上返回正数

        if (isrotate)
        {
            rotate_x += Input.GetAxis("Mouse X");
            rotate_y += Input.GetAxis("Mouse Y");

            //camera.transform.Rotate(new Vector3(-y*rotatespeed,x*rotatespeed,0),Space.Self);
            camera.gameObject.transform.rotation= Quaternion.Euler(-rotate_y*2, rotate_x*2, 0);
        }
       

    }

    //按下鼠标中键，控制摄像机的上下左右移动
    void Movecamera()
    {
        if (Input.GetMouseButtonDown(2)) ismove = true;
        if (Input.GetMouseButtonUp(2)) ismove = false;
        if (ismove == true)
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            //camera.transform.position += new Vector3(x  , y  , 0);
            camera.transform.position += transform.TransformDirection(new Vector3(x, y, 0));
        }
       
        
    }
}
