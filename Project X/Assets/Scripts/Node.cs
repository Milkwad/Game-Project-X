using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    
    public GameObject Unitprefab;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Instantiate(Unitprefab, transform.position + new Vector3(0,0.5f,0), transform.rotation);
        
    }
}
