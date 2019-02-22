using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour {
    public GameObject car;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void InstanceObstacle()
    {

        GameObject instance = Instantiate(car, new Vector3(), Quaternion.identity);
    }
}
