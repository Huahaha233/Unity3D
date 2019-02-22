using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public GameObject sentbullet;
    public float thrust = 2000.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject clone = Instantiate(sentbullet,transform.position, transform.rotation) as GameObject;
            Rigidbody rb = clone.GetComponent<Rigidbody>();
            rb.AddForce(clone.transform.forward * thrust);
            
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("manster"))
        {
            Destroy(this.gameObject);
        }
    }
}
