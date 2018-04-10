using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour {

	WaveManager waveManager;

	// Use this for initialization
	void Start () {
		waveManager = FindObjectOfType<WaveManager> ().GetComponent<WaveManager> ();
		// TODO clear code
		waveManager.WaveClearedEvent += (WaveController waveController) => {
			enableUpgradeMode();
		};

	}
	
	// Update is called once per frame
	void Update () {
	}

	void enableUpgradeMode() {
		// Announce Upgrade
		/*GameObject announcementUI = GameObject.Find("AnnouncementUI");
		AnnouncementController announcementController = announcementUI.GetComponent<AnnouncementController> ();
		announcementController.announce ("Upgrade Time!", () => {
			/Debug.Log("Upgrade Announcement Callback");
		});*/
	}
}
