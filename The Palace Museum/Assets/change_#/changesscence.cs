using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changesscence : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CreatDatabase();
        CreatTable();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private static void CreatDatabase()//创建数据库
    {
        string creatdatabase = "Data Source=localhost;Persist Security Info=yes;UserId=root;PWD=123456";
        string MysqlStatment = "CREATE DATABASE IF NOT EXISTS oldvillage DEFAULT CHARSET utf8 COLLATE utf8_general_ci;";
        MySqlConnection conn = new MySqlConnection(creatdatabase);
        try
        {
            conn.Open();
            MySqlCommand comm = new MySqlCommand(MysqlStatment, conn);
            comm.ExecuteNonQuery();
            Debug.Log("数据库建立完成");
        }
        catch
        {

        }
        finally
        {
            conn.Close();
        }

    }

    private static void CreatTable()//创建数据库表
    {
        string sql = "CREATE TABLE IF NOT EXISTS `User` (`User_id` INT UNSIGNED AUTO_INCREMENT,  `User_name` CHAR(10) NOT NULL, `User_psw` CHAR(10) NOT NULL,PRIMARY KEY(`User_id`)) DEFAULT CHARSET = utf8";
        ChangeMysql(sql);
        string sql1 = "CREATE TABLE IF NOT EXISTS `User_login` (`num` INT UNSIGNED AUTO_INCREMENT,  `User_name` CHAR(10) NOT NULL, `Login_time` DATETIME NOT NULL,PRIMARY KEY(`num`)) DEFAULT CHARSET = utf8";
        ChangeMysql(sql1);
        string sql2 = "CREATE TABLE IF NOT EXISTS `User_registe` (`registe_num` INT UNSIGNED AUTO_INCREMENT,  `User_name` CHAR(10) NOT NULL, `User_psw` CHAR(20) NOT NULL,`registe_time` DATETIME NOT NULL,PRIMARY KEY(`registe_num`)) DEFAULT CHARSET = utf8";
        ChangeMysql(sql2);

    }

    private static void ChangeMysql(string Mysql_change)//对数据库进行操作，通过其他函数传入的参数进行操作
    {
        string Mysql_str = "server=localhost;user id=root;password=123456;database=oldvillage";
        MySqlConnection myconn = new MySqlConnection(Mysql_str);
        try
        {
            myconn.Open();
            MySqlCommand mycomm = new MySqlCommand(Mysql_change, myconn);
            mycomm.ExecuteNonQuery();
            Debug.Log("建表完成");
        }
        catch (MySqlException ex)
        {
        }
        finally
        {
            myconn.Close();
        }
    }

    public void Toregiste()
    {
        SceneManager.LoadScene("registe");
    }
    public void Tologin()
    {
        SceneManager.LoadScene("login");
    }
    public void Totravle()
    {
        Collsion.isregiste= false;//给类LinkMysql中的值赋值，证明本用户不是注册用户
        SceneManager.LoadScene("SampleScene");
    }
}
