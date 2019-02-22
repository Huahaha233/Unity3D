using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Login : MonoBehaviour {
    public InputField user;
    public InputField psw;
	// Use this for initialization
	void Start () {
        CreatDatabase();
        CreatTable();
        AddInfoToMysql();/*添加的管理员账户与密码只是为了测试*/
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public static void CreatDatabase()//创建数据库
    {
        string creatdatabase = "Data Source=localhost;Persist Security Info=yes;UserId=root;PWD=123456";
        string MysqlStatment = "CREATE DATABASE IF NOT EXISTS oldvillage DEFAULT CHARSET utf8 COLLATE utf8_general_ci;";
        MySqlConnection conn = new MySqlConnection(creatdatabase);
        try
        {
            conn.Open();
            MySqlCommand comm = new MySqlCommand(MysqlStatment, conn);
            comm.ExecuteNonQuery();

        }
        catch
        {

        }
        finally
        {
            conn.Close();
        }

    }
    public static void CreatTable()//创建数据库表
    {
        string sql = "CREATE TABLE IF NOT EXISTS `model` (`oldvillage_ID` INT UNSIGNED AUTO_INCREMENT,  `oldvillage_name` CHAR(10) NOT NULL, `oldvillage_data` MEDIUMBLOB NOT NULL, `imagedata` MEDIUMBLOB NOT NULL, `wechat` CHAR(1) NOT NULL,`notes` CHAR(50),PRIMARY KEY(`oldvillage_ID`)) DEFAULT CHARSET = utf8";
        ChangeMysql(sql);
        string sql1 = "CREATE TABLE IF NOT EXISTS `admin` (`Admin_id` VARCHAR(2) NOT NULL,  `Admin_name` CHAR(10) NOT NULL, `Admin_sex` CHAR(1) NOT NULL, `Admin_psw` CHAR(10) NOT NULL, `Admin_conn` CHAR(11) NOT NULL,`notes` CHAR(50),PRIMARY KEY(`Admin_ID`)) DEFAULT CHARSET = utf8";
        ChangeMysql(sql1);

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
           
        }
        finally
        {
            myconn.Close();
        }
    }

    public void AddInfoToMysql()//向数据库中添加数据
    {
        /*添加的管理员账户与密码只是为了测试*/
        string sql = "insert into admin values('1','text','男','1','1','测试')";
        ChangeMysql(sql);
    }

    public int ReadMysql(string name, string psw)
    {
        int find = 0;
        string connetStr = "server=localhost;user id=root;password=123456;database=oldvillage";//注意Sslmode要赋值为none，否则无法连接到数据库   
        MySqlConnection conn = new MySqlConnection(connetStr);
        MySqlCommand command = null;
        MySqlDataReader dataReader = null;
        try
        {
            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM admin";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                if (name == dataReader.GetString(0) && psw == dataReader.GetString(3))
                {
                    find = 1;//find为1时，证明数据库中用户名已存在
                    break;
                }

            }
        }
        catch
        {
            Debug.Log("未能连接到数据库！");
        }
        finally { conn.Close(); }
        return find;

    }

    public void Judge()
    {
        
        if (ReadMysql(user.text, psw.text) == 1)
        {
            transform.Find("Tips").GetComponent<Text>().text = "登录成功！";
            Invoke("ToScene", 1f);//延迟1秒后跳转页面
        }
        else
        {
            transform.Find("Tips").GetComponent<Text>().text = "信息错误！";
        }
    }

    public void ToScene()
    {
        SceneManager.LoadScene("OpenFile");
    }
}
