using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemManager : MonoBehaviour {

	public static uint gemsCount = 0;

	public void collect(GameObject gem) {
		AudioSource collectSound = gem.GetComponent<AudioSource>();
		Animator animator = gem.GetComponent<Animator> ();
		GemController gemController = gem.GetComponent<GemController> ();
		animator.SetTrigger ("Collect");
		collectSound.Play();
		Destroy (gem.transform.parent.gameObject, 0.50f);
		gemsCount += gemController.value;
	}
}
