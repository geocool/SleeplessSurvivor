using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemManager : MonoBehaviour {

	public static uint gemsCount = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void collect(GameObject gem) {
		Animator animator = gem.GetComponent<Animator> ();
		animator.SetTrigger ("Collect");
		Destroy (gem, 0.50f);
		gemsCount++;
	}
}
