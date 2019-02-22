using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 心得：发现不用每一帧率都发送一条涉嫌，那样性能太低，浪费资源，所以每点击一次就发送一天射线
 这样既能节省电脑资源，提高优化，又能一次只控制一个物体，不会出现控制一个物体的时候
 误触其他物体 */
public class CameraRay : MonoBehaviour {
    public Camera camera;
    private Ray ray;
    private RaycastHit hit;
    private bool isshoot=false;
    private bool isclick = false;
    private float rotate_x = 0.0f;
    private float rotate_y = 0.0f;
    private float rotate_z = 0.0f;//定义旋转的角度
    private string hitname=null;//被射线射中的物体的名称
    private bool isopenlight = false;//是否已经开启灯光
    //private float offset_z = 0;//摄像机到被射线触碰的物体的偏移量
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Onclick();
        }

        if (isshoot==true)
        {
            FllowMove();
            ControlRotate();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
                OpenCloseLight();
        }
    }
    

    void Onclick()
    {
            ray = camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit))
            {
            if (isshoot == false && (hit.collider.gameObject.tag != "floor"))
            {
                isshoot = true;
            }
            else
            {
                isshoot = false;
            }
            
                
            }
    }

    
    //控制到物体随鼠标运动
    void FllowMove()
    {
        //offset_z = Mathf.Abs(hit.collider.gameObject.transform.position.z-camera.gameObject.transform.position.z);
        hit.collider.gameObject.transform.position = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,15));
       
    }
    
    /*这个函数是控制被射线击中物体的旋转*/
    void ControlRotate()
    {

                if (Input.GetKeyDown(KeyCode.W))
                {
                    rotate_x += 45.0f;
                    //以下两种方式都可行
                    //hit.collider.gameObject.transform.localEulerAngles = new Vector3(rotate_x,0.0f,0.0f);
                    hit.collider.gameObject.transform.rotation = Quaternion.Euler(rotate_x, rotate_y,rotate_z);
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    rotate_x -= 45.0f;
                    hit.collider.gameObject.transform.rotation = Quaternion.Euler(rotate_x, rotate_y, rotate_z);
                }

                if (Input.GetKeyDown(KeyCode.A))
                {
                    rotate_z += 45.0f;
                   hit.collider.gameObject.transform.rotation = Quaternion.Euler(rotate_x, rotate_y, rotate_z);
                }

                if (Input.GetKeyDown(KeyCode.D))
                {
                    rotate_z-= 45.0f;
                    hit.collider.gameObject.transform.rotation = Quaternion.Euler(rotate_x, rotate_y, rotate_z);
                }
    }

    void OpenCloseLight()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag != "floor"&&(hit.collider.gameObject.tag == "Light"))
            {
                    if (hit.collider.gameObject.transform.GetChild(0).gameObject.activeSelf==false) isopenlight = true;
                    else isopenlight = false;

                    //hit.collider.transform.Find("bedlight_L").gameObject.SetActive(true);
                    //hit.collider.transform.Find("bedlight_R").gameObject.SetActive(true);
                    hit.collider.gameObject.transform.GetChild(0).gameObject.SetActive(isopenlight);
                    hit.collider.gameObject.transform.GetChild(1).gameObject.SetActive(isopenlight);
                 
            }

        }
    }
}
