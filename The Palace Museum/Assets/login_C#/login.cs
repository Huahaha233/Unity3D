using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class login : MonoBehaviour {
    public InputField Guser;
    public InputField Gpsw;
    public InputField Gcode;
    private string Code;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangeMysql(string Mysql_change)//对数据库进行操作，通过其他函数传入的参数进行操作
    {
        string Mysql_str = "server=localhost;user id=root;password=123456;database=oldvillage";
        MySqlConnection myconn = new MySqlConnection(Mysql_str);
        try
        {
            myconn.Open();
            MySqlCommand mycomm = new MySqlCommand(Mysql_change, myconn);
            mycomm.ExecuteNonQuery();
            Debug.Log("写入成功");
        }
        catch (MySqlException ex)
        {
        }
        finally
        {
            myconn.Close();
        }
    }

  
    public int ReadMysql(string name,string psw)
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
            command.CommandText = "SELECT * FROM User_registe";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                if (name == dataReader.GetString(1)&&psw==dataReader.GetString(2))
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



    /*判断注册用户名是都存在*/
    public void Judge()
    {
        Code = Mysqlconn.Code;//放于此处用于更新code的值
        if (ReadMysql(Guser.text,Gpsw.text) == 1&&(Code == Gcode.text))
        {
           transform.Find("Tips").GetComponent<Text>().text = "登录成功！";
            Collsion.isregiste = true;//给类LinkMysql中的值赋值，证明本用户不是注册用户
            Invoke("ToScene", 1f);//延迟1秒后跳转页面
        }
        else
        {
            transform.Find("Tips").GetComponent<Text>().text = "信息错误！";
            VerificationCode.Click();//验证码错误使用需要刷新验证码

        }
    }

    public void ToScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
