using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollector : MonoBehaviour {

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag("Player")) {
			GemManager gemManager = GameObject.Find ("GemManager").transform.GetComponent<GemManager> ();
			gemManager.collect (gameObject);
		}
	}
}
