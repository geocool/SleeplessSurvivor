using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour {

	public float lifeTime = 5f;

	private float timer = 0;
	bool lockGemAction = false; // Make sure gem won't be destroyed while is been collected

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

		if (other.gameObject.CompareTag("Player") && !lockGemAction) {
			lockGemAction = true;
			GemManager gemManager = GameObject.Find ("GemManager").transform.GetComponent<GemManager> ();
			gemManager.collect (gameObject);
		}
	}

	void destroyGem() {
		if (!lockGemAction) {
			lockGemAction = true;
			Destroy (transform.parent.gameObject);
		}
	}
}
