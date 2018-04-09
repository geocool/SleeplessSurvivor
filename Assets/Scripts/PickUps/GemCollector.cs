using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollector : MonoBehaviour {

	AudioSource collectSound;

	// Use this for initialization
	void Start () {
		collectSound = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag("Player")) {
			//GemManager.collect (gameObject); // TODO fix this
			Animator animator = GetComponent<Animator> ();
			animator.SetTrigger ("Collect");
			collectSound.Play ();
			Destroy (gameObject, 0.50f);
		}
	}
}
