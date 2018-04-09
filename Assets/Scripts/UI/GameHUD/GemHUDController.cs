using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemHUDController : MonoBehaviour {

	Text gemCountText;

	// Use this for initialization
	void Start () {
		gemCountText = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		gemCountText.text = GemManager.gemsCount.ToString();
	}
}
