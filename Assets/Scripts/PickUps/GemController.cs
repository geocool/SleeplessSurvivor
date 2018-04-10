using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour {

	public float lifeTime = 5f;

	private float timer = 0;

	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate () {
		timer += Time.deltaTime;

		if (timer >= lifeTime) {
			destroyGem ();
		}
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag("Player")) {
			GemManager gemManager = GameObject.Find ("GemManager").transform.GetComponent<GemManager> ();
			gemManager.collect (gameObject);
		}
	}

	void destroyGem() {
		Destroy (transform.parent.gameObject);
	}
}
