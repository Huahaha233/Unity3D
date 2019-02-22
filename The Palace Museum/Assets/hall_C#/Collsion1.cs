using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*此脚本是控制用户从建筑物中出来的脚本*/
public class Collsion1 : MonoBehaviour {
    public GameObject text;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && (text.activeSelf == true))
        {
            SceneManager.LoadScene("SampleScene");
            //跳转回主界面
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
}
