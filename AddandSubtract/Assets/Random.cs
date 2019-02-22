using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Random : MonoBehaviour {
    private int a, b, c, d, button;
    private int Istrue = 0;//0为等待状态，1为正确，2为错误
    private int bridge = 3;
    private float speed =(float)0.5;
    public GameObject obj;
    // Use this for initialization
    void Start () {
        //Find();
	}
	
	// Update is called once per frame
	void Update () {
        if (Istrue == 1)
        {
            if ((bridge == 2) && obj.transform.position.x > 0.6)
            {
                obj.transform.Translate(Vector3.forward*speed*Time.deltaTime);
                if(obj.transform.position.x <= 0.6)
                {
                    obj.GetComponent<Animator>().SetBool("iswalk", false);
                    Istrue = 0;
                    transform.Find("button").gameObject.SetActive(true);
                }
               
            }
            if ((bridge == 1) && obj.transform.position.x > -0.4)
            {
                obj.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                if (obj.transform.position.x <= -0.4)
                {
                    obj.GetComponent<Animator>().SetBool("iswalk", false);
                    Istrue = 0;
                    transform.Find("button").gameObject.SetActive(true);
                }
            }
            if ((bridge == 0) && obj.transform.position.x > -2)
            {
                obj.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                if (obj.transform.position.x <= -2)
                {
                    obj.GetComponent<Animator>().SetBool("iswalk", false);
                    Istrue = 0;
                    transform.Find("win").gameObject.SetActive(true);
                    Invoke("ReStart", 2);

                }
            }
        }
       
    }
    public void Button1()
    {
        int x = a + b;
        if(transform.Find("button/Button1").GetComponentInChildren<Text>().text ==x.ToString())
        {
            Istrue = 1;
        }
        else
        {
            Istrue = 2;
        }
        Judge();
    }
    public void Button2()
    {
        int x = a + b;
        if (transform.Find("button/Button2").GetComponentInChildren<Text>().text == x.ToString())
        {
            Istrue = 1;
        }
        else
        {
            Istrue = 2;
        }
        Judge();
    }
    public void Button3()
    {
        int x = a + b;
        if (transform.Find("button/Button3").GetComponentInChildren<Text>().text == x.ToString())
        {
            Istrue = 1;
        }
        else
        {
            Istrue = 2;
        }
        Judge();
    }
    public void Button4()
    {
        int x = a + b;
        if (transform.Find("button/Button4").GetComponentInChildren<Text>().text == x.ToString())
        {
            Istrue = 1;
        }
        else
        {
            Istrue = 2;
        }
        Judge();
    }
    public void OnStart()
    {
        Find();
        transform.Find("Start").gameObject.SetActive(false);
    }
    public void Find()
    {
       
        a = Ran(10);
        b = Ran(10);
        c =d = a + b;
        button = Ran(5);
        transform.Find("Text1").GetComponent<Text>().text = a.ToString();
        transform.Find("Text2").GetComponent<Text>().text = "+";
        transform.Find("Text3").GetComponent<Text>().text = b.ToString();

        
        //transform.Find("Button"+button).GetComponentInChildren<Text>().text = c.ToString();
        for(int i = button; i >= 1; i--)
        {
            transform.Find("button/Button" + i).GetComponentInChildren<Text>().text = (c--).ToString();
        }
        for (int i = button; i <= 4; i++)
        {
            transform.Find("button/Button" + i).GetComponentInChildren<Text>().text = (d++).ToString();
        }
    }
    public int Ran(int z)
    {
        int x = UnityEngine.Random.Range(1,z);
        return x;
    }
    public void Judge()
    {
        switch (Istrue)
        {
            case 0:

                break;

            case 1:
                Move();
                break;

            case 2:
                Default();
                break;
        }
    }

    public void Move()
    {
        transform.Find("bridge"+(bridge--)).gameObject.SetActive(true);
        transform.Find("button").gameObject.SetActive(false);
        obj.GetComponent<Animator>().SetBool("iswalk",true);
        Find();
    }
    public void Default()
    {
        obj.GetComponent<Animator>().SetBool("iswalk", false);
        transform.Find("end").gameObject.SetActive(true);
        transform.Find("button").gameObject.SetActive(false);
        Invoke("ReStart", 2);
    }
    public void ReStart()
    {
        SceneManager.LoadScene("SampleScene");//重新加载场景
    }
}
