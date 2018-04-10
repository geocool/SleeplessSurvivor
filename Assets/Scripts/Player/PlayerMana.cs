using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMana : MonoBehaviour {

	public int currentMana = 100;
	public int maxMana = 100;
	[Tooltip("MP Per Second")]
	public int regenerationRate = 1;
	public Slider manaSlider;
	float timer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		timer += Time.deltaTime;

		regenerateMana ();
	}

	void regenerateMana() {
		if (timer >= 1) {
			timer = 0;
			currentMana += regenerationRate;
			if (currentMana > maxMana)
				currentMana = maxMana;

			updateSlider ();
		}
	}

	public bool hasEnoughtMana(int manaRequired) {
		return currentMana >= manaRequired;
	}

	public void useMana(int manaUsed) {
		currentMana -= manaUsed;
		currentMana = currentMana < 0 ? 0 : currentMana;

		updateSlider ();
	}

	private void updateSlider () {
		manaSlider.value = currentMana;
	}
}
