using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System;
using System.Text;
using Hont;//using Hont 这样就可以调用ObjFormatAnalyzer和ObjFormatAnalyzerFactory两个类，传入相关参数然后实例化
using Newtonsoft.Json;
using UnityEngine.UI;
using UnityEditor;

public class LinkMysql : MonoBehaviour {
    byte[] imagedata = new byte[1024];//初始化imagedata
        // Use this for initialization
	void Start () {
        ReadMysql();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ReadMysql()
    {
        string obj_json = null;
        string connetStr = "server=localhost;user id=root;password=123456;database=oldvillage";//注意Sslmode要赋值为none，否则无法连接到数据库   
        MySqlConnection conn = new MySqlConnection(connetStr);
        MySqlCommand command = null;
        MySqlDataReader dataReader = null;
        try
        {
            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM model";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                obj_json = dataReader.GetString(2);//获取oldvillage_data列的数据
                imagedata = (byte[])dataReader["imagedata"];//获取贴图的数据流
            }
        }
        catch
        {
            Debug.Log("未能连接到数据库！");
        }
        finally{conn.Close(); }
        //Debug.Log(obj_json);
        JsonToString(obj_json);
    }



    public void JsonToString(string obj_json)
    {
        //string Path = "C:\\Users\\Administrator\\Desktop\\9186\\Garen.obj";
        //Debug.Log(File.ReadAllText("C:\\Users\\Administrator\\Desktop\\9186\\Garen.obj")); //读取路径下的文件的所有文本值

        string obj_str = (string)JsonConvert.DeserializeObject(obj_json);//反序列化
        //Debug.Log(obj_str);

        GameObject obj = ObjFormatAnalyzerFactory.AnalyzeToGameObject(obj_str);
        //if (obj == null) Debug.Log("空");
        Instance(obj);
    }

    //public void  ByteToObject(byte[] Bytes)//将byte[]转化为obj格式
    //{
    //    using (MemoryStream ms = new MemoryStream(Bytes))
    //    {
    //        IFormatter formatter = new BinaryFormatter(); 
    //        object obj=formatter.Deserialize(ms);
    //        //Instance(obj);//将obj保存在unity3D的assent文件夹下再读取obj文件
    //    }

    //}

    public void Instance(GameObject obj)//将obj格式的文件实例化在unity3D中
    {
        obj.transform.name = "model";//设置名称
        //GameObject instance = (GameObject)Instantiate(obj,new Vector3(0,0,0),new Quaternion(180,0,0,0));
        //Instantiate(obj, new Vector3(10,0,0),Quaternion.identity);
        Creat(obj);
        Mat(obj);//添加材质
        
    }
    public void Mat(GameObject obj)
    {
        //Texture2D texture= AssetDatabase.LoadAssetAtPath("Assets/texture.png", typeof(Texture2D)) as Texture2D;
        Texture2D texture =new Texture2D(80,80);
        texture.LoadImage(imagedata);
        Material mat = new Material(Shader.Find("Standard"));
        mat.mainTexture = texture;
        obj.gameObject.GetComponent<Renderer>().material = mat;
    }
    public void Creat(GameObject obj)
    {
        GameObject museum = new GameObject("The Palace Museum");
        GameObject floorbox = new GameObject("floor box");
        GameObject maudiencehall = new GameObject("audience hall");
        GameObject registe = new GameObject("registe");

        maudiencehall.AddComponent<Collsion>();//添加脚本
        maudiencehall.GetComponent<Collsion>().text = transform.Find("Text").gameObject;//可以查找的隐藏的物体

        registe.AddComponent<Collsion>();//添加脚本
        if (Collsion.isregiste == true)
        {
            registe.GetComponent<Collsion>().text = transform.Find("Text_registe").gameObject;//可以查找的隐藏的物体
        }
        else
        {
            registe.GetComponent<Collsion>().text = transform.Find("Text_noregiste").gameObject;//可以查找的隐藏的物体
        }
        

        obj.transform.parent = museum.transform;//将museum设为obj的父类
        floorbox.transform.parent = museum.transform;
        maudiencehall.transform.parent = museum.transform;
        registe.transform.parent = museum.transform;

        Position(museum,0,0,0,0,0,0,1,1,1);
        Position(floorbox, -25, -45, -50, 0, 0, 0, 1,1,1);
        Position(registe, -20, -29, 22, 0, 0, 0, 1, 1, 1);
        Position(maudiencehall, -23, -29, -75, 0, 0, 0, 1,1,1);//强制转换
        Position(obj, 0, 0, 0, -5, 120, 180, 100,100,100);

        AddComponent(floorbox,false, 0, 0, 0, 200, 10, 200);
        AddComponent(maudiencehall, true, 0, 0, 0, 80, 20, 50);
        AddComponent2(maudiencehall, false, 0, 0, 0, 60, 20, 40);
        
        AddComponent(registe, true, 0, 0, 0, 60, 20, 40);
        AddComponent2(registe, false, 0, 0, 0, 50, 20, 30);

    }
    public void Position(GameObject gameObject,float x,float y,float z,float a, float b,float c,float d,float e,float f)
    {
        gameObject.transform.position = new Vector3(x, y, z);//调整位置
        gameObject.transform.rotation = Quaternion.Euler(a,b,c);//调整角度
        gameObject.transform.localScale= new Vector3(d,e,f);
    }

    public void AddComponent(GameObject gameObject,bool istrigger, float a, float b, float c, float d, float e, float f)
    {
        gameObject.AddComponent<Rigidbody>();//添加刚体
        gameObject.AddComponent<BoxCollider>();//添加触发器
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<BoxCollider>().isTrigger = istrigger;
        gameObject.GetComponent<BoxCollider>().center = new Vector3(a,b,c);//设置boxcollider的位置
        gameObject.GetComponent<BoxCollider>().size = new Vector3(d,e,f);//设置boxcollider的位置
    }
    public void AddComponent2(GameObject gameObject, bool istrigger, float a, float b, float c, float d, float e, float f)
    {
        //只有再命名一个boxcollider，才能区分两个boxcollsider，才能进行正确的赋值
        BoxCollider boxCollider1=gameObject.AddComponent<BoxCollider>();//添加触发器
        boxCollider1.isTrigger = istrigger;
        boxCollider1.center = new Vector3(a, b, c);//设置boxcollider的位置
        boxCollider1.size = new Vector3(d, e, f);//设置boxcollider的位置
    }

}
