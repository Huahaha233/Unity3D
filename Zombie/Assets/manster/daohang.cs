using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class daohang : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        
       
    }
	
	// Update is called once per frame
	void Update () {

            GameObject manstertarget = GameObject.FindGameObjectWithTag("manstertarget");
            GetComponent<NavMeshAgent>().destination = manstertarget.transform.position;
        
	}
}
