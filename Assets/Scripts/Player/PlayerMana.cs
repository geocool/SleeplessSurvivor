using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMana : MonoBehaviour {

	public int currentMana = 100;
	public int maxMana = 100;
	public Slider manaSlider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool hasEnoughtMana(int manaRequired) {
		return currentMana >= manaRequired;
	}

	public void useMana(int manaUsed) {
		currentMana -= manaUsed;
		currentMana = currentMana < 0 ? 0 : currentMana;

		manaSlider.value = currentMana;
	}
}
