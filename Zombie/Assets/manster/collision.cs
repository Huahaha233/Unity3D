using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour {
    private static int count = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
           
        
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            
            GetComponent<Animator>().SetBool("Death", true);
            GameObject KILL = GameObject.FindGameObjectWithTag("KILL");
            KILL.GetComponent<TextMesh>().text = "KILL:"+(++count);
            Destroy(this.gameObject, 5.0f);
        }


        if (other.gameObject.CompareTag("soldier"))
        {
            GetComponent<Animator>().SetBool("Attack", true);
            GetComponent<Animator>().SetBool("Run", false);
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("soldier"))
        {
            GetComponent<Animator>().SetBool("Run", true);
            GetComponent<Animator>().SetBool("Attack", false);
        }
        
    }
    



}
