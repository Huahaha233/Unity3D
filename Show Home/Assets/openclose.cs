using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openclose : MonoBehaviour {
    private bool open=false;

    private static string whoopen= "windows_all";
    /*
     定义一个变量，存入已经在UI中开启的表的名称，
     然后就能根据这个变量来找到已经打开的表，然后关闭它，
     从而打开一个新的表
      */
      
   public void Openwindows()
    {
        if (open == false)
        {

            open = true;
        }
        else
        {

            open = false;
        }
        if (open == true)
        {
           transform.parent.Find(whoopen).gameObject.SetActive(false);
        
            transform.parent.Find("windows_all").gameObject.SetActive(true);
            whoopen = "windows_all";
        //注意一定要用到parent，否则搜索不到
        }
        else
        {
            transform.parent.Find("windows_all").gameObject.SetActive(false);
        }
    }

    public void Openbearbar()
    {
        if (open == false)
        {

            open = true;
        }
        else
        {

            open = false;
        }
        if (open == true)
        {
            
            transform.parent.Find(whoopen).gameObject.SetActive(false);
           
            whoopen = "bearbar_all";
            transform.parent.Find("bearbar_all").gameObject.SetActive(true);
            
            //注意一定要用到parent，否则搜索不到
        }
        else
        {
            transform.parent.Find("bearbar_all").gameObject.SetActive(false);
        }
    }

    public void Openbed()
    {
        if (open == false)
        {

            open = true;
        }
        else
        {

            open = false;
        }
        if (open == true)
        {
            
            transform.parent.Find(whoopen).gameObject.SetActive(false);
           
            whoopen = "bed_all";
            transform.parent.Find("bed_all").gameObject.SetActive(true);
            //注意一定要用到parent，否则搜索不到
        }
        else
        {
            transform.parent.Find("bed_all").gameObject.SetActive(false);
        }
    }

    public void Openchair()
    {
        if (open == false)
        {

            open = true;
        }
        else
        {

            open = false;
        }
        if (open == true)
        {
            
            transform.parent.Find(whoopen).gameObject.SetActive(false);
           
            whoopen = "chair_all";
            transform.parent.Find("chair_all").gameObject.SetActive(true);
            //注意一定要用到parent，否则搜索不到
        }
        else
        {
            transform.parent.Find("chair_all").gameObject.SetActive(false);
        }
    }



    public void Opensofa()
    {
        if (open == false)
        {

            open = true;
        }
        else
        {

            open = false;
        }
        if (open == true)
        {
           
            transform.parent.Find(whoopen).gameObject.SetActive(false);
           
            whoopen = "sofa_all";
            transform.parent.Find("sofa_all").gameObject.SetActive(true);
            //注意一定要用到parent，否则搜索不到
        }
        else
        {
            transform.parent.Find("sofa_all").gameObject.SetActive(false);
        }
    }



    public void Opentable()
    {
        if (open == false)
        {

            open = true;
        }
        else
        {

            open = false;
        }
        if (open == true)
        {
           
            transform.parent.Find(whoopen).gameObject.SetActive(false);
            
            whoopen = "table_all";
            transform.parent.Find("table_all").gameObject.SetActive(true);
            //注意一定要用到parent，否则搜索不到
        }
        else
        {
            transform.parent.Find("table_all").gameObject.SetActive(false);
        }
    }



    public void OpenTV()
    {
        if (open == false)
        {

            open = true;
        }
        else
        {

            open = false;
        }
        if (open == true)
        {
           
            transform.parent.Find(whoopen).gameObject.SetActive(false);
           
            whoopen = "TV_all";
            transform.parent.Find("TV_all").gameObject.SetActive(true);
            //注意一定要用到parent，否则搜索不到
        }
        else
        {
            transform.parent.Find("TV_all").gameObject.SetActive(false);
        }
    }


    public void Openwooden()
    {
        if (open == false)
        {

            open = true;
        }
        else
        {

            open = false;
        }
        if (open == true)
        {
           transform.parent.Find(whoopen).gameObject.SetActive(false);
           
            whoopen = "wooden_all";
            transform.parent.Find("wooden_all").gameObject.SetActive(true);
            //注意一定要用到parent，否则搜索不到
        }
        else
        {
            transform.parent.Find("wooden_all").gameObject.SetActive(false);
        }
    }


}
