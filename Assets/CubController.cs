using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("mouse 0")) {
			transform.position = transform.position + new Vector3(0.0f ,0.0f, 0.1f);
		}

	}
}
