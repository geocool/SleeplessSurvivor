using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnnouncementController : MonoBehaviour {

	public delegate void OnEndCallback();
	private OnEndCallback currentCallback;
	Text announcementText;
	Animator animator;

	void Start () {
		announcementText = gameObject.transform.GetChild (0).GetComponent<Text> ();
		animator = GetComponent<Animator> ();
	}

	public void announce(string message,OnEndCallback onEndCallback) {
		announcementText.text = message;
		currentCallback = onEndCallback;
		animator.SetTrigger ("Announce");
	}

	void OnAnnouncementEnd() {
		if(currentCallback != null)
			currentCallback ();
	}
}
