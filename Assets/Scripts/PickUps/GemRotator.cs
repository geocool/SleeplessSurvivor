using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemRotator : MonoBehaviour {

	public float rotateSpeed = 50f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
	
		// Unit Vector
		Vector3 rotation = Vector3.up;
		transform.Rotate (Vector3.up * rotateSpeed * Time.deltaTime);


	}
}
