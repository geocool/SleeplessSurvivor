using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayerController : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		Vector3 rotation = player.transform.position - transform.position;
		rotation.y = 0f;
		Quaternion newRotation = Quaternion.LookRotation (rotation);
		GetComponent<Rigidbody> ().MoveRotation (newRotation);
	}
}
