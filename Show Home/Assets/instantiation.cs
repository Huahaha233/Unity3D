using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiation : UIDragDropItem {
     public GameObject prefab;
    public Camera camera;
    // Use this for initialization
    protected override void OnDragDropRelease(GameObject surface)
    {
        if (surface != null&&(Input.GetMouseButtonUp(0)))
        {
            //注意此处一定要用到camera.ScreenToWorldPoint将试图坐标转化为世界坐标，否则无法在想要的位置实例化
            GameObject.Instantiate(prefab,camera.ScreenToWorldPoint( new Vector3(Input.mousePosition.x,Input.mousePosition.y,5)),Quaternion.identity);
        };
        base.OnDragDropRelease(surface);
    }
    
}
