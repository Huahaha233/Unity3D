using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using HedgehogTeam.EasyTouch;

public class soldier : MonoBehaviour {
    private static int count=100;
    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Gesture currentGesture = EasyTouch.current;
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Animator>().SetBool("shoot", true);
            GetComponent<Animator>().SetBool("idle", false);
            GetComponent<Animator>().SetBool("run", false);
        }
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Animator>().SetBool("shoot", false);
            GetComponent<Animator>().SetBool("idle", true);
            GetComponent<Animator>().SetBool("run", false);
        }
        if(Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("shoot", false);
            GetComponent<Animator>().SetBool("idle", false);
            GetComponent<Animator>().SetBool("run",true);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("shoot", false);
            GetComponent<Animator>().SetBool("idle", true);
            GetComponent<Animator>().SetBool("run", false);
        }
        if (count <= 0)
        {
            SceneManager.LoadScene("Gameover");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sword"))
        {
            count -= 50;
            GameObject HP = GameObject.FindGameObjectWithTag("HP");
            HP.GetComponent<TextMesh>().text = "HP:" +count;
           
            
        }

    }
    
}
