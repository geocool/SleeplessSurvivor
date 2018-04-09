using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {

	Animator animator;
	bool isPaused = false;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Pause")) {
			if (!isPaused) {
				pauseGame ();
			} else {
				continueGame ();
			}
		}
	}

	void pauseGame () {
		Debug.Log ("Pausing Game");
		animator.SetTrigger ("Pause");
		isPaused = true;
		Time.timeScale = 0;
	}

	void continueGame () {
		Debug.Log ("Continue Game");
		animator.SetTrigger ("Continue");
		isPaused = false;
		Time.timeScale = 1;
	}
}
