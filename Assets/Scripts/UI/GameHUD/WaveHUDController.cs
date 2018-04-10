using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveHUDController : MonoBehaviour {

	Text waveNumberText;
	Text waveTimerText;
	WaveManager waveManager;

	// Use this for initialization
	void Start () {
		Text[] texts = GetComponentsInChildren<Text> ();
		waveTimerText = texts [0];
		waveNumberText = texts [1];
		waveManager = FindObjectOfType<WaveManager> ().transform.GetComponent<WaveManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		updateWaveUI ();
	}

	void updateWaveUI() {
		waveNumberText.text = "Wave " + waveManager.getWaveNumber ().ToString ();
		int timeUntilEnd = waveManager.getTimeUntilEndOfWave ();
		int minutes = timeUntilEnd / 60;
		int seconds = timeUntilEnd % 60;
		string minutesString = minutes.ToString ().Length == 2 ? minutes.ToString () : "0" + minutes.ToString ();
		string secondsString = seconds.ToString ().Length == 2 ? seconds.ToString () : "0" + seconds.ToString ();
		waveTimerText.text = minutesString + ":" + secondsString;
	}
}
