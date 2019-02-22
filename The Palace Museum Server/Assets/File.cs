using UnityEngine;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using UnityEditor;
using Newtonsoft.Json;

public class File : MonoBehaviour {

    private string obj_json;
    //private byte[] imagedata = new byte[8000000];
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    

    public void AddInfoToMysql(byte[] imagedata)//向数据库中添加数据
    {
        /*当存储的文件过大时，一定要在MySQL的my.ini文件中修改max_allowed_packet的值，并重新启动MySQL*/
        string sql = "insert into model(oldvillage_ID,oldvillage_name,oldvillage_data,imagedata,wechat,notes) values('1','test','" + obj_json + "',@imagedata,'是','测试')";
        //ChangeMysql(sql);

        string Mysql_str = "server=localhost;user id=root;password=123456;database=oldvillage;Sslmode=none";

        MySqlConnection myconn = new MySqlConnection(Mysql_str);
        try
        {
            myconn.Open();
            MySqlCommand mycomm = new MySqlCommand(sql, myconn);
            mycomm.Parameters.AddWithValue("@imagedata", imagedata);
            Debug.Log("赋值完成");
            mycomm.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            myconn.Close();
        }

    }



    public static void ChangeMysql(string Mysql_change)//对数据库进行操作，通过其他函数传入的参数进行操作
    {
        string Mysql_str = "server=localhost;user id=root;password=123456;database=oldvillage";
        MySqlConnection myconn = new MySqlConnection(Mysql_str);
        try
        {
            myconn.Open();
            MySqlCommand mycomm = new MySqlCommand(Mysql_change, myconn);
            mycomm.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            myconn.Close();
        }
    }
    /*打开文件夹，选择obj文件，将obj文件转化为byte[]格式，保存至数据库*/
    public void OpenFile()//打开文件夹
    {
        //string objPath = "";
        string extion = "obj";
        string path = "";
        path = EditorUtility.OpenFilePanel("Load obj of Directory", Application.dataPath, extion);
        if (path != null)
        {
            Debug.Log("获取文件路径成功：" + path);
            //objPath = path;
        }
        string obj = System.IO.File.ReadAllText(path);//obj文件可以以文本的形式打开，此方法可以获取obj文本形式的值

        /*将字符串形式的obj文件转化为json格式*/
        obj_json = JsonConvert.SerializeObject(obj);
        
        ImageToByte();
        
    }

    public void ImageToByte()//将图转化为byte[]格式
    {
        
        string extion = "png,jpg";
        string path = "";
        path = EditorUtility.OpenFilePanel("Load Images of Directory", Application.dataPath, extion);
        if (path != null)
        {
            Debug.Log("获取文件路径成功：" + path);
        }
        
        FileStream fs = new FileStream(path, FileMode.Open);
        //BinaryReader br = new BinaryReader(fs);
        //byte[] imagedata = br.ReadBytes((int)fs.Length); //将流读入到字节数组中
        byte[] imagedata = new byte[fs.Length];
        fs.Read(imagedata, 0, imagedata.Length);
        fs.Close();
        Debug.Log(imagedata.Length);
        AddInfoToMysql(imagedata);

        
    }
    //public static byte[] ObjectToBytes(object obj)//将obj文件转化为byte[]格式
    //{

    //    using (MemoryStream ms = new MemoryStream())
    //    {
    //        IFormatter formatter = new BinaryFormatter();
    //        formatter.Serialize(ms, obj);
    //        return ms.GetBuffer();
    //    }
    //}
    //public static object ByteToObject(byte[] Bytes)//将byte[]转化为obj格式
    //{
    //    using (MemoryStream ms = new MemoryStream(Bytes))
    //    {
    //        IFormatter formatter = new BinaryFormatter();
    //        return formatter.Deserialize(ms);
    //    }
    //}
}




