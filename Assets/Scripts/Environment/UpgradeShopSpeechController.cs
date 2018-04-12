using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeShopSpeechController : MonoBehaviour {

	Animator animator;
	UpgradeShopTrigger upgradeShopTrigger;

	// Use this for initialization
	void Start () {
		animator = GameObject.Find("HUDCanvas").GetComponent<Animator> ();
		GameObject shopTrigger = GameObject.Find ("ShopTrigger");
		upgradeShopTrigger = shopTrigger.GetComponent<UpgradeShopTrigger> ();
		upgradeShopTrigger.UpgradeShopEnteredAreaEvent += showBubble;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void showBubble() {
		Debug.Log ("showBubbleCalled");
		animator.SetTrigger ("ShowInfo");
	}
}
