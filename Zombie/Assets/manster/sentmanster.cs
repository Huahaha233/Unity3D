using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sentmanster : MonoBehaviour {

    public GameObject manster;
    public int mansternumber;
    private int count=0;
    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (count < mansternumber)
        {
          Instantiate(manster, new Vector3(Random.Range(1810f, 1820f), 324, Random.Range(1850f, 1910f)), Quaternion.identity);
            count++;
        }
       


	}
    
}
