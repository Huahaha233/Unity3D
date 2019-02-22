using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public GameObject people;
    private float speed = 1;
    public float s;
    private int road = 2;

    //这里的roadnum数组是马路上道路的编号，马路一共分为了4条道路，
    //数组的值为人物在对应道路上的相应值
    private double[] roadnum = new double[4] {1.25,1.75,2.25,2.75 };

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        people.transform.Translate(Vector3.forward*Time.deltaTime*speed,Space.World);

        Jump();
        ChangeLoad();
        
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            people.transform.GetComponent<Animator>().SetBool("isjump",true);
            Invoke("End", 0.3f);
        }
        
    }
    
    private void ChangeLoad()
    {
        if (Input.GetKeyDown(KeyCode.A)&&(road>0))
        {
            //people.transform.GetComponent<Animator>().SetBool("isjump", true);
            //Invoke("End", 0.3f);
            road -= 1;
            MoveRoad();
        }
        
        if (Input.GetKeyDown(KeyCode.D)&&(road<3))
        {
            //people.transform.GetComponent<Animator>().SetBool("isjump", true);
            //Invoke("End", 0.3f);
            road += 1;
            MoveRoad();
        }
      

    }
    private void MoveRoad()
    {
        float step = 1000 * Time.deltaTime;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,new Vector3((float)roadnum[road],0,gameObject.transform.position.z),step);
    }

    private void End()
    {
        people.transform.GetComponent<Animator>().SetBool("isjump", false);
    }
    
}
