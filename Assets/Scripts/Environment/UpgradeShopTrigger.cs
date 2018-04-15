using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeShopTrigger : MonoBehaviour {

	public delegate void UpgradeShopEnter();
    public delegate void UpgradeShopExit();
    public delegate void UpgradeShopEnteredArea ();
	public delegate void UpgradeShopExitedArea ();
    public event UpgradeShopEnter UpgradeShopEnterEvent;
    public event UpgradeShopExit UpgradeShopEnterExit;
    public event UpgradeShopEnteredArea UpgradeShopEnteredAreaEvent;
	public event UpgradeShopExitedArea UpgradeShopExitedAreaEvent;

    public bool isTriggered;

    private Light light;
	// Use this for initialization
	void Start () {
        light = GameObject.Find("UpgradeShopLight").GetComponent<Light>();
	}

	void FixedUpdate () {
		// If user pressed the action button and there is trigger flag
		// Start Upgrade shop animation && change cameras
	}
	
	void OnTriggerEnter (Collider other) {
		// Check if player triggered && set flag triggered
		// Show a message to inform for action button

		if (other.tag == "Player") {
			Debug.Log("Shop Trigger Enter");
            light.enabled = true;
            isTriggered = true;
            if (UpgradeShopEnteredAreaEvent != null) {
				UpgradeShopEnteredAreaEvent ();
			}
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.tag == "Player") {
			Debug.Log("Shop Trigger Exit");
            light.enabled = false;
            isTriggered = false;
            if (UpgradeShopExitedAreaEvent != null) {
				UpgradeShopExitedAreaEvent ();
			}
		}
	}

	void enterShop () {
		if (UpgradeShopEnterEvent != null) {
			UpgradeShopEnterEvent ();
		}
	}

    void exitShop () {
        if (UpgradeShopEnterExit != null) {
            UpgradeShopEnterExit ();
        }
    }
}
